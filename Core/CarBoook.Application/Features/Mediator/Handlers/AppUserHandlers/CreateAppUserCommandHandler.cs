using CarBook.Domain.Entities;
using CarBoook.Application.Enums;
using CarBoook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.Username,
                Password = request.Password,
                // AppRoleID= 3, // Default
                AppRoleID = (int)RoleTypes.Member, // Enum
            });
        }
    }
}
