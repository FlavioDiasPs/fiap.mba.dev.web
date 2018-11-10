using AutoMapper;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Fiap.StackOverflow.Web.Models;
using Fiap.StackOverflow.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fiap.StackOverflow.Infra.Data.IdentityExtension;
using System.Security.Claims;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Web.Controllers
{
    public class QuestionController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper, IUnitOfWork unitOfWork, IQuestionService questionService, IAuthorService authorService) : base(unitOfWork)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
            _authorService = authorService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var questions = _questionService.GetQuestions().Select(x => new QuestionModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                AuthorId = x.AuthorId,
                //Author = x.Author.Name
                //Tags = x.Tags
            }).ToList();

            var vm = new QuestionViewModel{ Questions = questions };

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var question = _questionService.GetCompleteById(id);
            ViewBag.LastestQuestions = _questionService.GetAll()
                                            .OrderByDescending(x => x.Id)
                                            .Take(5)
                                            .Select(x => new KeyValuePair<int, string>(x.Id, x.Title))
                                            .ToList();

            return View(_mapper.Map<QuestionModel>(question));
        }
        //[Authorize]
        public ActionResult Create()
        {
            var m = new QuestionModel();
            LoadCreate(m);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var author = _authorService.GetByIdentityId(userId);
            if(author == null)
            {
                author = new Author(User.Identity.Name ,userId);
                try
                {
                    _authorService.Add(author);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            m.AuthorId = author.Id;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("AuthorId,Title,Description")] QuestionModel questionModel)
        {
            var m = new QuestionModel();
            LoadCreate(m);

            if (ModelState.IsValid)
            {
                try
                {
                    var question = new Question(questionModel.AuthorId, questionModel.Title, questionModel.Description);

                    _unitOfWork.BeginTransactionAnsyc();

                    _questionService.Add(question);

                    _unitOfWork.SaveChanges();
                    _unitOfWork.Commit();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    _unitOfWork.RollbackTransaction();
                    return View(m);
                }
            }
            else
            {
                return View(m);
            }
        }
        private QuestionModel LoadCreate(QuestionModel questionModel)
        {
            questionModel.Authors = _authorService.GetAll().Select(x => new SelectListItem()
             {
                 Value = x.Id.ToString(),
                 Text = x.Name.ToString()
             }).ToList();
            return questionModel;
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
            //Adicionada o filter no mvc em startup pra não precisar validar model
            //if (ModelState.IsValid)
            //{
                var question = _questionService.GetById(id);

                try
                {
                    _unitOfWork.BeginTransactionAnsyc();

                    question.Title = questionModel.Title;
                    question.Description = questionModel.Description;

                    _questionService.Update(question);

                    _unitOfWork.Commit();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    return View();
                }
            //}
            //return View();
        }

        public ActionResult Delete(int id)
        {
            var question = (QuestionModel)_questionService.GetCompleteById(id);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var question = _questionService.GetById(id);
            try
            {
                _unitOfWork.BeginTransactionAnsyc();
                _questionService.Remove(question);

                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                return View();
            }
        }
    }
}