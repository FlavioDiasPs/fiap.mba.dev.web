using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.StackOverflow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IAnswerService _answerService;

        public QuestionController(IMapper mapper, IUnitOfWork unitOfWork, IQuestionService questionService, IAuthorService authorService, IAnswerService answerService) : base(unitOfWork)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
            _authorService = authorService;
            _mapper = mapper;
            _answerService = answerService;
        }
        // GET: api/Question
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            var questions = _questionService.GetAll();
            return questions;
        }

        // GET: api/Question/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var question = _questionService.GetById(id);
            return Ok(question);
        }

        // POST: api/Question
        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            _questionService.Add(question);
            return Ok();
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Question question)
        {
            if (id != question.Id)
                return BadRequest();
            _questionService.Add(question);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //_questionService.Remove(id);
            return Ok();
        }
    }
}
