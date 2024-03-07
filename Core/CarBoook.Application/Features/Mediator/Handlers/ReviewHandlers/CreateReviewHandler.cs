using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CustomerName = request.CustomerName,
				CustomerImage = request.CustomerImage,
				Comment = request.Comment,
				RatingValue = request.RatingValue,
				CarID = request.CarID,
				ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
			});
		}
	}
}
