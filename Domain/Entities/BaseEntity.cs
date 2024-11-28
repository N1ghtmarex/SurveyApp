namespace Domain.Entities
{
    public abstract class BaseEntity<T> where T: notnull
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public T Id { get; set; } = default!;
    }
}
