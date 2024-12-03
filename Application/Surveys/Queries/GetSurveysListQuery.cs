using Application.Surveys.Dtos;
using MediatR;

namespace Application.Surveys.Queries
{
    public class GetSurveysListQuery : IRequest<SurveyListViewModel>
    {
    }
}
