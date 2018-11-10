using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fiap.StackOverflow.Api.ServiceModel;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.StackOverflow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IAnswerService _answerService;

        public AnswerController(IMapper mapper, IUnitOfWork unitOfWork, IQuestionService questionService, IAuthorService authorService, IAnswerService answerService) : base(unitOfWork)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
            _authorService = authorService;
            _mapper = mapper;
            _answerService = answerService;
        }
        // GET: api/Question
        [HttpGet("{QuestionId}")]
        public IEnumerable<Answer> Get(int QuestionId)
        {
            var answers = _answerService.GetAll();
            var xpto = answers.Where(a => a.QuestionId != QuestionId);
            return xpto;
        }

        //// GET: api/Question/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value "+ id ;
        //}

        // POST: api/Question
        [HttpPost]
        public IActionResult Post([FromBody]AnswerModel resposta)
        {
            var answer = _mapper.Map<Answer>(resposta);
            _answerService.Add(answer);

            return Ok();    
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AnswerModel resposta)
        {
            if (id != resposta.QuestionId)
                return BadRequest();
            var answer = _mapper.Map<Answer>(resposta);
            _answerService.Add(answer);

            return Ok();    
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Answer a = new Answer(id);
            //_answerService.Remove(id);
        }
    }
}
