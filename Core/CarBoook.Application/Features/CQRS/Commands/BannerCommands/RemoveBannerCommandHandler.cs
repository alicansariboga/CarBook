using CarBook.Domain.Entities;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
