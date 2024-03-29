﻿using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBoook.Application.Interfaces.BlogInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).ToList();
            return values;
        }

        public List<Blog> GetBlogsByAuthorId(int id)
        {
            var values = _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            // select last(3) * from blogs order by blogID desc
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
