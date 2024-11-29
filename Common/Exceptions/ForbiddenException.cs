namespace Common.Exceptions
{
    /// <summary>
    /// Модель исключения, выдаваемого при отказе в доступе
    /// </summary>
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base() { }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }
    }
}
