using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public IEnumerable<QuestionTag> GetQuestionsTagByTagId(int id)
        {
            return _repository.GetQuestionsTagByTagId(id);
        }

        //public Dictionary<Tag, int> GetTagCloud(int quantity)
        //{
        //    var parameters = new SqlParameter[] { new SqlParameter("@Quantity", quantity.ToString())};
        //    var tags1 = _repository.FromSql(new TagCloud() , @"SELECT TOP (CONVERT(INT,@Quantity)) Id, QuestionId, TagId
        //                                           ,COUNT(0) Count  FROM[dbo].[QuestionTag]  GROUP BY Id, QuestionId, TagId  ORDER BY COUNT(0) DESC", parameters);

        //    var tags = _repository.GetTagCloud();
        //    //.GroupBy(info => info.Tag)
        //    //.Select(group => new {
        //    //    Tag = group.Key,
        //    //    Count = group.Count()
        //    //})
        //    //.OrderByDescending(x => x.Count)
        //    //.Take(quantity)
        //    //.ToDictionary(x => x.Tag, x=>x.Count);

        //    var tagg = tags.Select(c => new
        //    {
        //        c.Tag
        //    }).GroupBy(c => c.Tag, (k, g) => new
        //    {
        //        Tag = k,
        //        Count = g.Count()
        //    }).OrderByDescending(x => x.Count).Take(quantity);

        //    return tagg.ToDictionary(x => x.Tag, x => x.Count);
        //}

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
