﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
