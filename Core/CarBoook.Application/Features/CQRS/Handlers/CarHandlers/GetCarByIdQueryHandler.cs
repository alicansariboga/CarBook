using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Queries.BrandQueries;
using CarBoook.Application.Features.CQRS.Queries.CarQueries;
using CarBoook.Application.Features.CQRS.Results.BrandResults;
using CarBoook.Application.Features.CQRS.Results.CarResult;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID=values.CarID,
                BrandID = values.BrandID,
                Model = values.Model,
                CoverImageUrl = values.CoverImageUrl,
                Km = values.Km,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fuel = values.Fuel,
                BigImageUrl = values.BigImageUrl
            };
        }
    }
}
