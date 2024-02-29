﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Commands.CarFeatureCommand
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand : IRequest
    {
        public UpdateCarFeatureAvailableChangeToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
