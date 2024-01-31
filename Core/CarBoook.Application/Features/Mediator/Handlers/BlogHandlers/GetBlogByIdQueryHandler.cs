﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.Mediator.Queries.BlogQueries;
using CarBoook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBoook.Application.Features.Mediator.Results.BlogResults;
using CarBoook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogID = values.BlogID,
                Title = values.Title,
                AuthorID = values.AuthorID,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                CategoryID = values.CategoryID,
                Description = values.Description
            };
        }
    }
}
