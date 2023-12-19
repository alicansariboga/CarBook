using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Commands.BannerCommands;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
                Decription = command.Decription,
                Title = command.Title,
                VideoDescripton = command.VideoDescripton,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
