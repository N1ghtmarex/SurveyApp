namespace Common.Exceptions
{
    /// <summary>
    /// Модель исключения, выдаваемого в случае, когда объект не существует в базе данных
    /// </summary>
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base() { }
        public ObjectNotFoundException(string message) : base(message) { }
        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
