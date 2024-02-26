using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,
                Email = request.Email,
                CarID = request.CarID,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                Age = request.Age,
                LicenseYear = request.LicenseYear,
                Description = request.Description,
                Status = "Rezervasyon Alındı.",
            });
        }
    }
}
