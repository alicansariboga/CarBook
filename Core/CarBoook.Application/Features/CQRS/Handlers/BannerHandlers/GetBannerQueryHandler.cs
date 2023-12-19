using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Results.BannerResults;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Decription=x.Decription,
                Title = x.Title,
                VideoDescripton=x.VideoDescripton,
                VideoUrl=x.VideoUrl
            }).ToList();
        }  
    }
}
