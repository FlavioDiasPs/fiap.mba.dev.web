using AutoMapper;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.ViewComponents
{
    public class TagCloudViewComponent : ViewComponent
    {
        private readonly IQuestionTagService _questionTagService;
        private readonly IMapper _mapper;
        public TagCloudViewComponent(IMapper mapper, IQuestionTagService questionTagService)
        {
            _mapper = mapper;
            _questionTagService = questionTagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int quantity)
        {
            var tags = _questionTagService.GetTagCloud(quantity).ToDictionary(x => _mapper.Map<TagModel>(x.Key), x => x.Value);

            return View("TagCloud", tags);
        }
    }
}
