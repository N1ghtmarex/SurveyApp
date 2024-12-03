namespace Common.Exceptions
{
    /// <summary>
    /// Модель исключения, выдаваемого в случае, когда объект уже существует в базе данных
    /// </summary>
    public class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException() : base() { }
        public ObjectAlreadyExistsException(string message) : base(message) { }
        public ObjectAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
