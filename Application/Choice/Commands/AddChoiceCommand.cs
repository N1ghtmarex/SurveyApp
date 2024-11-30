using Application.Choice.Dtos;
using MediatR;

namespace Application.Choice.Commands
{
    public class AddChoiceCommand : IRequest<string>
    {
        public required AddChoiceModel Body { get; set; }
    }
}
