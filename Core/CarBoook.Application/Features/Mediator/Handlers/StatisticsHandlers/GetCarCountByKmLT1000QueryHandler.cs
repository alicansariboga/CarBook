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
    public class GetCarCountByKmLT1000QueryHandler : IRequestHandler<GetCarCountByKmLT1000Query, GetCarCountByKmLT1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmLT1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmLT1000QueryResult> Handle(GetCarCountByKmLT1000Query request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByKmLT1000();
            return new GetCarCountByKmLT1000QueryResult
            {
                CarCountByKmLT1000 = values,
            };
        }
    }
}
