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
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewID);
			values.CustomerName = request.CustomerName;
			values.ReviewDate = request.ReviewDate;
			values.CustomerImage = request.CustomerImage;
			values.CarID = request.CarID;
			values.RatingValue = request.RatingValue;
			values.Comment = request.Comment;
		}
	}
}
