using AutoMapper;
using GildedRose.Application.Features.Articles.Commands.CreateArticle;
using GildedRose.Application.Features.Articles.Commands.UpdateArticlesList;
using GildedRose.Domain;

namespace GildedRose.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<UpdateArticlesListCommand, Article>()
            .ForMember(d => d.Price, s => s.MapFrom<UpdateArticlesListCommandCustomResolver.PriceResolver>())
            .ForMember(d => d.Quality, s => s.MapFrom<UpdateArticlesListCommandCustomResolver.QualityResolver>())
            .ForMember(d => d.SellIn, s => s.MapFrom<UpdateArticlesListCommandCustomResolver.SellInResolver>());
        }
    }
}
