using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger_5._0
{
    internal sealed partial class MessengerUI
    {
        public static void MainPage(Account account)
        {
            Console.Clear();
            MessengerUI services = new MessengerUI();
            IEnumerable<Account> OwnerContacts;
            int order;
            ContactsView(account, services, out OwnerContacts, out order);
            Console.WriteLine($"\n\n\t\t\t\t\t\t{order}. Settings ");
            Console.Write("\n\n\n\t\t\t\t\t\tInput : ");
            int input = int.Parse(Console.ReadLine() ?? "0");
            if (input == order) SettingsPage(account);
            else ChattingPage(account, OwnerContacts.ToList()[input - 1]);

        }

        private static void ContactsView(Account account, MessengerUI services, out IEnumerable<Account> OwnerContacts, out int order)
        {
            OwnerContacts = from contact in services._contactService.GetAllAsync().Result
                            join inneraccount in services._accountService.GetAllAsync().Result
                            on contact.InContactId equals inneraccount.AccountId
                            where contact.OwnerAccountId == account.AccountId
                            select inneraccount;
            order = 1;
            Console.WriteLine("\t\t\t\t+------------------------------------------------------+ ");

            Console.WriteLine("\t\t\t\t|\t\t\t Contacts                      | ");
            Console.WriteLine("\t\t\t\t+------------------------------------------------------+ ");
            foreach (var contact in OwnerContacts)
            {
                Console.WriteLine($"\t\t\t\t|\t\t{order}| {contact.FirstName}     \t                       |");
                Console.WriteLine("\t\t\t\t+------------------------------------------------------+ ");
                order++;
            }

        }

        private static void BackToMainPage(Account account)
        {
            Console.WriteLine("Invalid Input ");
            Console.ReadKey();
            MainPage(account);
        }

    }
}
