﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBoook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SocialMediaID);
            values.Name = request.Name;
            values.Url = request.Url;
            values.Icon= request.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}