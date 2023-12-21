using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Results.BrandResults;
using CarBoook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBoook.Application.Features.Mediator.Results.FeatureResults;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>> // where TRequest : MediatR.IRequest<List<GetFeatureQueryResult>>
        // IRequestHandler <Request, Response>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureID=x.FeatureID,
                Name = x.Name
            }).ToList();
        }
    }
}
