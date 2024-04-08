﻿using CarRentalManagement.Application.Features.RepositoryPattern;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarRentalContext _context;

        public CommentRepository(CarRentalContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
           _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentId);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x=>new Comment
            {
               CommentId = x.CommentId,
               BlogId = x.BlogId,
               CreatedDate = x.CreatedDate,
               Description = x.Description,
               Name = x.Name,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Update(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }
    }
}
