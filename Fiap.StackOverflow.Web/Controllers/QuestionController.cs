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
using Newtonsoft.Json;

namespace Fiap.StackOverflow.Web.Controllers
{
    public class QuestionController : Base.ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IQuestionTagService _questionTagService;

        public QuestionController(IMapper mapper, IUnitOfWork unitOfWork, IQuestionService questionService, IAuthorService authorService, ICategoryService categoryService, ITagService tagService, IQuestionTagService questionTagService) : base(unitOfWork)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
            _authorService = authorService;
            _mapper = mapper;
            _categoryService = categoryService;
            _tagService = tagService;
            _questionTagService = questionTagService;
        }
        public ActionResult Index()
        {
            var questions = _questionService.GetQuestions().Select(x => _mapper.Map<QuestionModel>(x)).ToList();

            var vm = new QuestionViewModel { Questions = questions };

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
            if (User.Identity.IsAuthenticated)            
                ViewBag.AuthorId = _authorService.GetByIdentityId(User.FindFirstValue(ClaimTypes.NameIdentifier)).Id;            
            else            
                ViewBag.NaoLogado = true;
            

            return View(_mapper.Map<QuestionModel>(question));
        }
        [Authorize]
        public ActionResult Create()
        {
            var m = new QuestionModel();

            LoadCreate(m);

            return View(m);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CategoryId,Title,Description,SelectedTags")] QuestionModel questionModel)
        {
            var m = new QuestionModel();
            LoadCreate(m);

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.BeginTransactionAnsyc();

                    var question = new Question(AuthorVerify().Id, questionModel.CategoryId, questionModel.Title, questionModel.Description);

                    _questionService.Add(question);

                    var questionTags = new List<QuestionTag>();

                    foreach (var tag in JsonConvert.DeserializeObject<List<TagModel>>(questionModel.SelectedTags))
                    {
                        if (tag.Id.HasValue)
                        {
                            questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = (int)tag.Id });
                        }
                        else
                        {
                            var newTag = new Tag() { Name = tag.Value };
                            _tagService.Add(newTag);
                            questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = newTag.Id });
                        }
                    }

                    question.QuestionTags = questionTags;

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

        private Author AuthorVerify()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var author = _authorService.GetByIdentityId(userId);
            if (author == null)
            {
                try
                {
                    author = new Author(User.Identity.Name, userId);
                    _authorService.Add(author);
                }
                catch (Exception e)
                {
                    throw;
                }

            }
            return author;
        }
        private QuestionModel LoadCreate(QuestionModel questionModel)
        {
            questionModel.Categories = _categoryService.GetAll().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();
            questionModel.Tags = _tagService.GetAll().Select(x => _mapper.Map<TagModel>(x)).ToList();

            return questionModel;
        }
        public ActionResult Edit(int id)
        {
            var model = _mapper.Map<QuestionModel>(_questionService.GetCompleteById(id));// (QuestionModel)_questionService.GetCompleteById(id);
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
            var question = _mapper.Map<QuestionModel>(_questionService.GetCompleteById(id));
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