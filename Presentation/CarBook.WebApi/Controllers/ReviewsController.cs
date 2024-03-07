using CarBoook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBoook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBoook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> ReviewListByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			// The validator object and SOLID were not damaged much.
			CreateReviewValidator validator = new CreateReviewValidator();
			var validationResult = validator.Validate(command);

			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("Ekleme işlemi basarili bir sekilde gerçekleşti.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			await _mediator.Send(command);
			return Ok("Güncelleme işlemi basarili bir sekilde gerçekleşti.");
		}
	}
}
