using Domein.Entities;
using Domein.Repositories;
using Persistence;
using Persistence.Repositories;
using Service.Abstractions;
using Services;
using Services.Abstractions;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Messanger_5._0
{
    internal sealed partial class MessengerUI
    {
        public static void RegistrationPage()
        {
            Console.Clear();
            MessengerUI services = new MessengerUI();
            Console.WriteLine("\n\n\n\n\t\t\t\t\t Welcome to My Messenger                        ");
            Console.Write("\t\t\t\t\tInput Your Number: ");
            string number = Console.ReadLine();
            if (!Regex.IsMatch(number, "^\\+998\\d{9}$")) BackToRegistration();
            var FoundedAccount = from account in services._accountService.GetAllAsync().Result
                                 where account.PhoneNumber == number
                                 select account;
            if (FoundedAccount.Count()==0)
            {
                string name = "";
               
                    Console.Write("\t\t\t\t\t Enter your Name :  ");
                    name = Console.ReadLine();
                    if (name == "") BackToRegistration();
                Account account = new Account()
                {
                    FirstName = name,
                    PhoneNumber = number
                };
                services._accountService.AddAsync(account);
                services._bunchOfAccountService.AddAsync(new BunchOfAccount() { InnerAccountId = account.AccountId }).Wait();
                services._unitOfWork.SaveChangesAsync();
                File.WriteAllText(CurrentAccountIdPath,account.AccountId.ToString());
                MainPage(account);
            }
            else
            {
                services._bunchOfAccountService.AddAsync(new BunchOfAccount() { InnerAccountId = FoundedAccount.ToList()[0].AccountId }).Wait();
                services._unitOfWork.SaveChangesAsync();
                File.WriteAllText(CurrentAccountIdPath, FoundedAccount.ToList()[0].AccountId.ToString());
                MainPage(FoundedAccount.ToList()[0]);
            }
        }
        private static void BackToRegistration()
        {
            Console.WriteLine("\t\t\t\t\t Invalid Input. ");
            Console.ReadKey();
            RegistrationPage();
        }
    }
}
