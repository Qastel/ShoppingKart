namespace ShoppingKart.Concrete
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}
