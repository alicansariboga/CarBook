using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string Decription { get; set; }
        public string ImageUrl { get; set; }
    }
}
