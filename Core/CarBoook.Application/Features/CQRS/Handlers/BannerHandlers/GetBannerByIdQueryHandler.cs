using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Queries.BannerQueries;
using CarBoook.Application.Features.CQRS.Results.BannerResults;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Decription=values.Decription,
                Title = values.Title,
                VideoDescripton=values.VideoDescripton,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
