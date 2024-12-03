namespace Application.Abstractions.Models
{
    /// <summary>
    /// Модель, возвращающая идентификатор добавленой или измененной сущности
    /// </summary>
    /// <typeparam name="T">Тип (Guid)</typeparam>
    /// <param name="id">Идентификатор сущности</param>
    public class CreatedOrUpdatedEntityViewModel<T>(T id)
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public T Id { get; set; } = id;
    }

    public class CreatedOrUpdatedEntityViewModel(Guid id) : CreatedOrUpdatedEntityViewModel<Guid>(id);
}
