using AutoMapper;
using GildedRose.Domain;

namespace GildedRose.Application.Features.Articles.Commands.UpdateArticlesList
{
    public class UpdateArticlesListCommandCustomResolver
    {
        public class SellInResolver : IValueResolver<UpdateArticlesListCommand, Article, int>
        {
            public int Resolve(UpdateArticlesListCommand source, Article destination, int destMember, ResolutionContext context)
            {
                if(destMember > 0)
                return destMember - 1;

                return 0;
            }
        }
        public class QualityResolver : IValueResolver<UpdateArticlesListCommand, Article, int>
        {
            public int Resolve(UpdateArticlesListCommand source, Article destination, int destMember, ResolutionContext context)
            {
                int amount = source.Amount;

                if (destination.SellIn <= 0 && !destination.AgedBrie)
                    amount *= 2;

                if (!destination.AgedBrie && destMember > 0)
                    destMember -= amount;

                if (destination.AgedBrie && destMember < 50)
                    destMember += amount;

                return destMember;
            }
        }

        public class PriceResolver : IValueResolver<UpdateArticlesListCommand, Article, decimal>
        {
            public decimal Resolve(UpdateArticlesListCommand source, Article destination, decimal destMember, ResolutionContext context)
            {
                return destination.Quality * source.PriceCalculator;
            }
        }

    }
}
