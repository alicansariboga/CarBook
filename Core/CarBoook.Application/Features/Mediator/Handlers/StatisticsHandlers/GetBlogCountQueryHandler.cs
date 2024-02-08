using CarBoook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBoook.Application.Features.Mediator.Results.StatisticsResults;
using CarBoook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                BlogCount = values,
            };
        }
    }
}
