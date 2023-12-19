using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Commands.BrandCommands;
using CarBoook.Application.Features.CQRS.Commands.CarCommands;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);
            values.BrandID = command.BrandID;
            values.Model = command.Model;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Km = command.Km;
            values.Transmission = command.Transmission;
            values.Seat = command.Seat;
            values.Luggage = command.Luggage;
            values.Fuel = command.Fuel;
            values.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
