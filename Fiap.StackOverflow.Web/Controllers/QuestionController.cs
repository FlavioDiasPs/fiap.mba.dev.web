using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Fiap.StackOverflow.Web.Models;
using Fiap.StackOverflow.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiap.StackOverflow.Web.Controllers
{
    public class QuestionController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IUnitOfWork unitOfWork, IQuestionService questionService) : base(unitOfWork)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {

            var questions = _questionService.GetQuestions().Select(x=> new QuestionModel() {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                AuthorId = x.AuthorId,
                Author = x.Author.Name
                //Tags = x.Tags
            }).ToList();

            var vm = new QuestionViewModel();
            vm.Questions = questions;

            return View(vm);
        }
    }
}