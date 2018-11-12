using AutoMapper;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Web.Models;

namespace Fiap.StackOverflow.Web.Mapping
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("StackOverflowProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<QuestionModel, Question>().ReverseMap()
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : string.Empty))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}
