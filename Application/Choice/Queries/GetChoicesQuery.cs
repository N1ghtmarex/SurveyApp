using Application.Choice.Dtos;
using MediatR;

namespace Application.Choice.Queries
{
    public class GetChoicesQuery : IRequest<ChoiceListViewModel>
    {
        public required Guid UserId { get; set; }
        public required Guid SurveyId { get; set; }
    }
}
