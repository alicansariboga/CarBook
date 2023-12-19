using CarBook.Domain.Entities;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerID);
            values.Decription = command.Decription;
            values.Title = command.Title;
            values.VideoDescripton = command.VideoDescripton;
            values.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
