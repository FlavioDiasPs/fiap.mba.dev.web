using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;

namespace Fiap.StackOverflow.Core.Services
{
    public class QuestionTagService : IQuestionTagService
    {
        private readonly IQuestionTagRepository _repository;
        public QuestionTagService(IQuestionTagRepository repository)
        {
            _repository = repository;
        }
        public void Add(QuestionTag obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<QuestionTag> GetAll()
        {
            return _repository.GetAll();
        }

        public QuestionTag GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(QuestionTag obj)
        {
            _repository.Remove(obj);
        }

        public void Update(QuestionTag obj)
        {
            _repository.Update(obj);
        }
    }
}
