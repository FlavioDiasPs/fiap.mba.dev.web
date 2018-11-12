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
            CreateMap<Question, QuestionModel>()
                    //.ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : string.Empty))
                    .ForMember(dest => dest.QuestionTags, opt => opt.MapFrom(src => src.QuestionTags))
                    .ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Tag, TagModel>()
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();
        }
    }
}
