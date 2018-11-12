using AutoMapper;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.ViewComponents
{
    public class LastQuestionsViewComponent : ViewComponent
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public LastQuestionsViewComponent(IMapper mapper,IQuestionService questionService)
        {
            _mapper = mapper;
            _questionService = questionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int quantity)
        {
            var perguntas = _questionService.GetLastQuestions(quantity).Select(x => _mapper.Map<QuestionModel>(x));

            return View("LastQuestions", perguntas);
        }
    }
}
