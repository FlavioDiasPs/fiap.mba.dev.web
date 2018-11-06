using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }
        public void Add(Question obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            return _repository.GetAll();
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Question obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Question obj)
        {
            throw new NotImplementedException();
        }
    }
}
