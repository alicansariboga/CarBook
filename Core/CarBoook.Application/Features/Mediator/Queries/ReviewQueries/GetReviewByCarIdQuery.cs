using CarBoook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewByCarIdQuery : IRequest<List<GetReviewByCarIdQueryResult>>
	{
		public GetReviewByCarIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
