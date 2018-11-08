using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(User obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
