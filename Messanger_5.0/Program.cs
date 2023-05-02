namespace Messanger_5._0
{
    internal class Program
    {
        static readonly string CurrentAccountIdPath = "..\\..\\..\\CurrentAccountId.txt";
        static void Main()
        {
           AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            try
            {
                MessengerUI userobject = new MessengerUI();
                if (File.ReadAllText(CurrentAccountIdPath) == " ")
                {
                    MessengerUI.RegistrationPage();
                }
                Guid CurrrentAccountId = Guid.Parse(File.ReadAllText(CurrentAccountIdPath));
                var currentAccount = userobject._accountService.GetAllAsync().Result.FirstOrDefault(x => x.AccountId == CurrrentAccountId);
                if (currentAccount is null) throw new ArgumentNullException(nameof(currentAccount));
                else MessengerUI.MainPage(currentAccount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+e.Message);
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }

    }
}