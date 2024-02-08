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
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBrandCount();
            return new GetBrandCountQueryResult
            {
                BrandCount = values,
            };
        }
    }
}
