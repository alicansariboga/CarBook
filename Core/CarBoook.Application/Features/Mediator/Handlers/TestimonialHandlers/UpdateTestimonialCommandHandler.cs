﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestimonialID);
            values.Name = request.Name;
            values.Title = request.Title;
            values.Comment = request.Comment;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
