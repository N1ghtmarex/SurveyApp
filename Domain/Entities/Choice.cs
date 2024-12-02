namespace Domain.Entities
{
    public class Choice : BaseEntity<Guid>
    {
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public required Guid QuestionId { get; set; }
        public Question? Question { get; set; }
        public required Guid AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
