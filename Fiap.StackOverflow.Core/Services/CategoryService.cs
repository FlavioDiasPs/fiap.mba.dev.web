using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;

namespace Fiap.StackOverflow.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public void Add(Category obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
            throw new System.NotImplementedException();
        }

        public void Remove(Category obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Category obj)
        {
            _repository.Update(obj);
        }
    }
}
