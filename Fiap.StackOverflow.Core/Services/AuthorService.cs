using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public void Add(Author obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public Author GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Author GetCompleteById(int id)
        {
            return _repository.GetCompleteById(id);
        }

        public Author GetByIdentityId(string id)
        {
            return _repository.GetByIdentityId(id);
        }

        public void Remove(Author obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Author obj)
        {
            _repository.Update(obj);
        }

    }
}
