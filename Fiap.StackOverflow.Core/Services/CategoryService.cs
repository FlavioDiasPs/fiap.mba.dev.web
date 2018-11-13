using System.Collections.Generic;
using System.Linq;
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
            var values = _repository.GetAll().ToList();
            if (!values.Any())
            {
                Add(new Category()
                {
                    Description = ".NET Core",
                    Name = ".NET Core"
                });
                Add(new Category()
                {
                    Description = ".NET Framework",
                    Name = ".NET Framework"
                });
            }

            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
            throw new System.NotImplementedException();
        }

        public Category GetCompletedById(int id)
        {
            return _repository.GetCompletedById(id);
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
