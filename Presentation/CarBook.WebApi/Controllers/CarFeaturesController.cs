using CarBoook.Application.Features.Mediator.Commands.CarFeatureCommand;
using CarBoook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBoook.Application.Features.Mediator.Queries.BlogQueries;
using CarBoook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("OK.");
        }
        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("OK.");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme işlemi başarılı bir şekilde tamamlandı.");
        }
    }
}
