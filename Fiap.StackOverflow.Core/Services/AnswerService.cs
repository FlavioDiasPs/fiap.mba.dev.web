using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;

        public AnswerService(IAnswerRepository repository)
        {
            _repository = repository;
        }
        public void Add(Answer obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _repository.GetAll();
        }

        public Answer GetById(int id)
        {
            return _repository.GetById(id);
        }   

        public void Remove(Answer obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Answer obj)
        {
            _repository.Update(obj);
        }
    }
}
