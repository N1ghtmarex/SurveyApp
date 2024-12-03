﻿using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Commands
{
    public class StartSurveyCommand : IRequest<string>
    {
        [FromBody]
        public required StartOrCompleteSurveyModel Body { get; set; }
    }
}