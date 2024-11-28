namespace Domain.Abstractions
{
    public interface IHaveDeleteTrack
    {
        /// <summary>
        /// Статус удаления
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
