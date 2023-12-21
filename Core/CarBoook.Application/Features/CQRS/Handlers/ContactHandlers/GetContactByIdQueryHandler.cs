﻿using CarBook.Domain.Entities;
using CarBoook.Application.Features.CQRS.Queries.ContactQueries;
using CarBoook.Application.Features.CQRS.Results.ContactResults;
using CarBoook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email = values.Email,
                Subject = values.Subject,
                Message = values.Message,
                SendDate = values.SendDate
            };
        }
    }
}
