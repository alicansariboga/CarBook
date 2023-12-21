using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Queries.BrandQueries;
using CarBoook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBoook.Application.Features.CQRS.Results.BrandResults;
using CarBoook.Application.Features.CQRS.Results.CategoryResults;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
            }).ToList();
        }
    }
}
