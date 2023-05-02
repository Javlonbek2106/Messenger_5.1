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
        public static void ChattingPage(Account SenderAccount, Account RecieverAccount)
        {
            Console.Clear();
            MessengerUI services = new MessengerUI();
            var Messages = from message in services._messageService.GetAllAsync().Result
                           where (message.SenderAccountId == SenderAccount.AccountId
                           && message.RecieverAccountId == RecieverAccount.AccountId) ||
                           (message.SenderAccountId == RecieverAccount.AccountId
                           && message.RecieverAccountId == SenderAccount.AccountId)
                           select message;
            Messages.OrderBy(message => message.SentTime);
            ChattingView(SenderAccount, RecieverAccount, Messages);
            Console.Write("\t\t\t\t\n\n\t\t Message : ");
            string InputMessage = Console.ReadLine() ?? "";
            if (InputMessage == "") MainPage(SenderAccount);
            services._messageService.AddAsync(new Message()
            {
                MessageText = InputMessage,
                RecieverAccountId = RecieverAccount.AccountId,
                SenderAccountId = SenderAccount.AccountId,
                SentTime = DateTime.Now
            });
            if (!services._contactService.GetAllAsync().Result.Any(x => x.OwnerAccountId == RecieverAccount.AccountId && x.InContactId == SenderAccount.AccountId))
                services._contactService.AddAsync(new Contact() { OwnerAccountId = RecieverAccount.AccountId, InContactId = SenderAccount.AccountId }).Wait();
            services._unitOfWork.SaveChangesAsync().Wait();
            ChattingPage(SenderAccount, RecieverAccount);
        }

        private static void ChattingView(Account SenderAccount, Account RecieverAccount, IEnumerable<Message> Messages)
        {
            Console.WriteLine("\t+---------------------------------------------------------------------------------------------+ ");

            Console.WriteLine($"\t|\t\t\t\t\t  {RecieverAccount.FirstName}                        \t              | ");
            Console.WriteLine("\t+---------------------------------------------------------------------------------------------+ ");
            foreach (var message in Messages)
            {
                if (message.SenderAccountId == SenderAccount.AccountId)
                    Console.WriteLine("\t|\t\t\t\t\t{0,-54}|",message.MessageText);
                else 
                    Console.WriteLine("\t|{0,-93}|",message.MessageText);
            }
            Console.WriteLine("\t+---------------------------------------------------------------------------------------------+ ");
        }
    }
}
