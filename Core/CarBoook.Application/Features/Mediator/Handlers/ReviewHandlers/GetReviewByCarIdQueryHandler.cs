﻿using CarBoook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBoook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBoook.Application.Features.Mediator.Results.PricingResults;
using CarBoook.Application.Features.Mediator.Results.ReviewResults;
using CarBoook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;

		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				ReviewID = x.ReviewID,
				CustomerName = x.CustomerName,
				CustomerImage = x.CustomerImage,
				Comment = x.Comment,
				RatingValue = x.RatingValue,
				ReviewDate = x.ReviewDate,
				CarID = x.CarID,
			}).ToList();
		}
	}
}
