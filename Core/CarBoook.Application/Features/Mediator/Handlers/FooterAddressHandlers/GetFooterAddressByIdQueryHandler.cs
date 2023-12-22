using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBoook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBoook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = values.FooterAddressID,
                Description = values.Description,
                Address = values.Address,
                Phone = values.Phone,
                Email = values.Email
            };
        }
    }
}
