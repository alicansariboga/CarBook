﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Queries.PricingQueries;
using CarBoook.Application.Features.Mediator.Results.LocationResults;
using CarBoook.Application.Features.Mediator.Results.PricingResults;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                PricingID = values.PricingID,
                Name = values.Name
            };
        }
    }
}
