using Application.Choice.Commands;
using Application.Choice.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/choice")]
    public class ChoiceController(ISender sender) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<string> MakeChoice(AddChoiceModel model, CancellationToken cancellationToken)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            model.UserId = Guid.Parse(userId);

            return await sender.Send(new AddChoiceCommand { Body = model }, cancellationToken);
        }
    }
}
