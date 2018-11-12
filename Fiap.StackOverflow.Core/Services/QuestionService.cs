using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _repository.Add(obj);
        }
        
        public IEnumerable<Question> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Question> GetAllComplete()
        {
            return _repository.GetAllComplete();
        }

        public Question GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Question GetCompleteById(int id)
        {
        
            return _repository.GetCompleteById(id);
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _repository.GetQuestions();
        }
        public IEnumerable<Question> GetQuestionsByTagId(int tagId)
        {
            return _repository.GetQuestionsByTagId(tagId);
        }

        public IEnumerable<Question> GetLastQuestions(int quantity)
        {
            return _repository.GetLastQuestions(quantity);
        }

        public void Remove(Question obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Question obj)
        {
            _repository.Update(obj);
        }
    }
}
