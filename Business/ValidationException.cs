


namespace Business
{
    public class ValidationExceptionA : Exception
    {
        public string Property { get; protected set; }
        public ValidationExceptionA (string message, string prop) : base(message) => Property = prop;
    }
}
