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
        private readonly ITagCloudService _tagCloudService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagCloudViewComponent(IMapper mapper, ITagCloudService tagCloudService, ITagService tagService)
        {
            _mapper = mapper;
            _tagCloudService = tagCloudService;
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int quantity)
        {
            var tags = _tagCloudService.GetTagCloud(quantity);
            return View("TagCloud", tags);
        }
    }
}
