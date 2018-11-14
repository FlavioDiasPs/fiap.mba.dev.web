using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;

namespace Fiap.StackOverflow.Core.Services
{
    public class TagCloudService : ITagCloudService
    {
        private readonly ITagCloudRepository _repository;
        public TagCloudService(ITagCloudRepository repository)
        {
            _repository = repository;
        }
        public void Add(TagCloud obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<TagCloud> GetAll()
        {
            return _repository.GetAll();
        }

        public TagCloud GetById(int id)
        {
            return _repository.GetById(id);
        }


        public List<Tuple<string, int, int>> GetTagCloud(int quantity)
        {
            var parameters = new SqlParameter[] { new SqlParameter("@Quantity", quantity.ToString()) };
            return _repository.FromSql(new TagCloud(), @"SELECT TOP (CONVERT(INT,@Quantity)) CAST(ROW_NUMBER() OVER (ORDER BY COUNT(0) DESC) AS INT) AS Id, Tag.Name TagName, COUNT(0) Count, TagId  FROM QuestionTag INNER JOIN Tag ON Tag.Id = QuestionTag.TagId GROUP BY TagId , Tag.Name ORDER BY COUNT(0) DESC", parameters)
                    .Select(x => new Tuple<string, int, int>(x.TagName, x.Count, x.TagId)).ToList();
        }

        public void Remove(TagCloud obj)
        {
            _repository.Remove(obj);
        }

        public void Update(TagCloud obj)
        {
            _repository.Update(obj);
        }
    }
}
