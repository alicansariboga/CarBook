﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Commands.AboutCommands;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AboutID);
            values.Decription=command.Decription;
            values.Title=command.Title;
            values.ImageUrl=command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
