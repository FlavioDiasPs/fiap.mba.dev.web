using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Fiap.StackOverflow.Web.Models;
using Fiap.StackOverflow.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiap.StackOverflow.Web.Controllers
{
    public class QuestionController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork, IQuestionService questionService) : base(unitOfWork)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var questions = _questionService.GetQuestions().Select(x => new QuestionModel()
            {
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

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            var question = _questionService.GetCompleteById(id);

            return View(new QuestionModel()
            {
                Author = question.Author.Name,
                AuthorId = question.AuthorId,
                Description = question.Description,
                Title = question.Title,
                Id = question.Id
            });
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = (QuestionModel)_questionService.GetCompleteById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Description")] QuestionModel questionModel)
        {
            
            if (ModelState.IsValid)
            {
                var question = _questionService.GetById(id);

                try
                {
                    question.Title = questionModel.Title;
                    question.Description = questionModel.Description;

                    _unitOfWork.Commit();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}