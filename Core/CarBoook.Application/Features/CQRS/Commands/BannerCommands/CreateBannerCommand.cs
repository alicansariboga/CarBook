using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateBannerCommand
    {
        public string Title { get; set; }
        public string Decription { get; set; }
        public string VideoDescripton { get; set; }
        public string VideoUrl { get; set; }
    }
}
