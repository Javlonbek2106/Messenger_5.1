using Domein.Entities;

namespace Messanger_5._0
{
    internal sealed partial class MessengerUI
    {
        public static void SettingsPage(Account account)
        {
            Console.Clear();
            Console.WriteLine(" \n\n\n\n\t\t\t\t1. Add Contact. ");
            Console.WriteLine(" \t\t\t\t2. Add Account. ");
            Console.WriteLine(" \t\t\t\t3. Change Account. ");
            Console.WriteLine(" \t\t\t\t4. Remove Contact. ");
            Console.WriteLine(" \t\t\t\t5. Remove Account. ");
            Console.WriteLine(" \t\t\t\t0. Back ");
            Console.Write("\n\n \t\t\t\tInput : ");
            int input = int.Parse(Console.ReadLine() ?? "0");
            Console.Clear();
            switch (input)
            {
                case 1:
                    AddContact(account);
                    break;
                case 2:
                    AddAccount(account);
                    break;
                case 3:
                    ChangingAccount(account);
                    break;
                case 4:
                    RemoveContact(account);
                    break;
                case 5:
                    RemoveAccount(account);
                    break;
                case 0:
                    MainPage(account);
                    break;

            }

            // The pgAdmin 4 server could not be contacted:
        }

        private static void RemoveAccount(Account account)
        {
            MessengerUI services = new MessengerUI();
            IEnumerable<Account> inneraccountss;
            int inputtt;
            InnerAccountsView(account, out inputtt, out inneraccountss);
            var foundinneraccount = services._bunchOfAccountService.GetAllAsync().Result.FirstOrDefault(x => x.InnerAccountId == inneraccountss.ToList()[inputtt - 1].AccountId);
            if (foundinneraccount is null)
                SettingsPage(account);
            else services._bunchOfAccountService.DeleteAsync(foundinneraccount.BunchOfAccountsId).Wait();
            Console.WriteLine("\n\t\t\t\t Successfully removed. ");
            Console.ReadLine();
            services._unitOfWork.SaveChangesAsync().Wait();
            MessengerUI services2 = new MessengerUI();
            var accountt = services2._bunchOfAccountService.GetAllAsync().Result.FirstOrDefault();
            if (accountt is null)
            {
                File.WriteAllText(CurrentAccountIdPath, " ");
                RegistrationPage();
            }
            else
            {
                File.WriteAllText(CurrentAccountIdPath, accountt.InnerAccountId.ToString());
                Account founnaccount = services2._accountService.GetAllAsync().Result.FirstOrDefault(x => x.AccountId == accountt.InnerAccountId) ?? account;
                MainPage(founnaccount);
            }
        }

        private static void RemoveContact(Account account)
        {
            MessengerUI services = new MessengerUI();
            int contactorder;
            IEnumerable<Account> OwnerContacts;
            ContactsView(account, services, out OwnerContacts, out contactorder);
            Console.WriteLine($"\n\n\t\t{contactorder}. Back ");
            Console.Write("\n\n\n\t\tInput : ");
            int inputt = int.Parse(Console.ReadLine() ?? "0");
            if (inputt == contactorder) SettingsPage(account);
            var foundcontact = from contact in services._contactService.GetAllAsync().Result
                               where contact.OwnerAccountId == account.AccountId &&
                               contact.InContactId == OwnerContacts.ToList()[inputt - 1].AccountId
                               select contact;
            services._contactService.DeleteAsync(foundcontact.ToList()[0].ContactId).Wait();
            Console.WriteLine("\n\t\t\t\t Successfully removed. ");
            services._unitOfWork.SaveChangesAsync();
            Console.ReadKey();
            MainPage(account);
        }

        private static void ChangingAccount(Account account)
        {
            MessengerUI services = new MessengerUI();
            int input;
            IEnumerable<Account> inneraccounts;
            InnerAccountsView(account, out input, out inneraccounts);
            Account findaccount = inneraccounts.ToList()[input - 1];
            File.WriteAllText(CurrentAccountIdPath, findaccount.AccountId.ToString());
            services._unitOfWork.SaveChangesAsync();
            Console.ReadKey();
            MainPage(findaccount);
        }

        private static void AddAccount(Account account)
        {
            MessengerUI services = new MessengerUI();
            Console.Write("\n\n\n\n\t\t\t\tInput Number: ");
            string accountnumber = Console.ReadLine() ?? "";
            if (accountnumber == "") SettingsPage(account);
            var FoundedAccount = services._accountService.GetAllAsync().Result.FirstOrDefault(account => account.PhoneNumber == accountnumber);
            if (FoundedAccount is null)
            {
                Console.Write("\t\t\t\tInput Name : ");
                string name2 = Console.ReadLine() ?? "";
                if (name2 == "") SettingsPage(account);
                services._accountService.AddAsync(new Account() { FirstName = name2, PhoneNumber = accountnumber });
                FoundedAccount = services._accountService.GetAllAsync().Result.Last();
            }
            services._bunchOfAccountService.AddAsync(new BunchOfAccount() { InnerAccountId = FoundedAccount.AccountId }).Wait();
            Console.WriteLine("\t\t\t\tsuccessfull added. ");
            services._unitOfWork.SaveChangesAsync();
            Console.ReadKey();
            MainPage(account);
        }

        private static void AddContact(Account account)
        {
            MessengerUI services = new MessengerUI();
            Console.Write("\n\n\n\n\t\t\t\tInput Number: ");
            string number = Console.ReadLine() ?? "";
            if (number == "") SettingsPage(account);
            List<Account> MatchedAccount = (from acc in services._accountService.GetAllAsync().Result
                                            where acc.PhoneNumber == number
                                            select acc).ToList();
            if (MatchedAccount.Count() == 0)
            {
                Console.Write("\t\t\t\tInput Name : ");
                string name = Console.ReadLine() ?? "";
                if (name == "") SettingsPage(account);
                MatchedAccount.Add(new Account() { AccountId = Guid.NewGuid(), FirstName = name, PhoneNumber = number });
                services._accountService.AddAsync(MatchedAccount[0]).Wait();
            }
            services._contactService.AddAsync(new Contact()
            {
                OwnerAccountId = account.AccountId,
                InContactId = MatchedAccount[0].AccountId
            }).Wait();
            Console.WriteLine("\t\t\t\tsuccessfull added. ");
            services._unitOfWork.SaveChangesAsync();
            Console.ReadKey();
            MainPage(account);
        }

        private static void InnerAccountsView(Account account, out int input, out IEnumerable<Account> inneraccounts)
        {
            MessengerUI services = new MessengerUI();
            inneraccounts = from inaccount in services._accountService.GetAllAsync().Result
                            where services._bunchOfAccountService.GetAllAsync().Result.Any(x => x.InnerAccountId == inaccount.AccountId)
                            select inaccount;
            Console.WriteLine("\n\n\t\t\t\tHere are your Accounts. \n");
            int order = 1;
            foreach (var innerAccount in inneraccounts.ToList())
            {
                Console.WriteLine($"\t\t\t\t{order}. {innerAccount.FirstName}");
                order++;
            }
            Console.WriteLine($"\t\t\t\t{order}. Back");
            Console.Write("\t\t\t\tInput: ");
            input = int.Parse(Console.ReadLine() ?? $"{order}");
            if (input == order) SettingsPage(account);
        }
    }
}
