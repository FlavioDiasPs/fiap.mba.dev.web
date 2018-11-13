using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;

namespace Fiap.StackOverflow.Core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }
        public void Add(Tag obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _repository.GetAll();
        }

        public Tag GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Remove(Tag obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Tag obj)
        {
            _repository.Update(obj);
        }
    }
}
