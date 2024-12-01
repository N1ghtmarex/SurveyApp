using Application.Choice.Dtos;
using Application.Choice.Queries;
using Domain;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Choice.Handlers
{
    internal class ChoiceQueriesHandlers(ApplicationDbContext dbContext)
        : IRequestHandler<GetChoicesQuery, ChoiceListViewModel>
    {
        public async Task<ChoiceListViewModel> Handle(GetChoicesQuery request, CancellationToken cancellationToken)
        {
            /////////////////////////
            var choices = await dbContext.Choices
                .Include(x => x.Answer)
                    .ThenInclude(x => x.Question)
                .Where(x => x.UserId == request.UserId && x.Answer.Question.SurveyId == request.SurveyId)
                .ProjectToType<ChoiceViewModel>()
                .ToListAsync(cancellationToken);

            return new ChoiceListViewModel { Choices = choices };
        }
    }
}
