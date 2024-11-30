using Microsoft.AspNetCore.Mvc;

namespace Application.Choice.Dtos
{
    public class AddChoiceModel
    {
        public Guid? UserId { get; set; }

        public required Guid AnswerId { get; set; }
    }
}
