namespace Domein.Exceptions
{
    public sealed class ContactNotFoundException : Exception
    {
        public ContactNotFoundException() : base("Contact not found. ")
        {
        }
    }
}
