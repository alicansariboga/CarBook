using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBoook.Application.Features.Mediator.Results.BlogResults;
using CarBoook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBoook.Application.Interfaces;
using CarBoook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)

        {
            var values = _repository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                FeatureName = x.Feature.Name,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                Available = x.Available,
            }).ToList();
        }
    }
}
