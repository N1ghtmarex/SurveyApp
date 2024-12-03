namespace Application.Choice.Dtos
{
    /// <summary>
    /// Модель для добавления выбора варианта ответа
    /// </summary>
    public class AddChoiceModel
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public required Guid AnswerId { get; set; }
    }
}
