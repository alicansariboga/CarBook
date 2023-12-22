using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBoook.Application.Features.Mediator.Results.LocationResults;
using CarBoook.Application.Features.Mediator.Results.ServiceResults;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceID = values.ServiceID,
                Title = values.Title,
                Description = values.Description,
                IconUrl = values.IconUrl
            };
        }
    }
}
