using CarBoook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBoook.Application.Features.Mediator.Results.StatisticsResults;
using CarBoook.Application.Interfaces.CarInterfaces;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CarBoook.Application.Interfaces.StatisticsInterfaces;

namespace CarBoook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAuthorCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                AuthorCount = values,
            };
        }
    }
}
