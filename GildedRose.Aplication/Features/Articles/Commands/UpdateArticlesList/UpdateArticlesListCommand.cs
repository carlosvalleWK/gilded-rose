using MediatR;

namespace GildedRose.Application.Features.Articles.Commands.UpdateArticlesList
{
    public class UpdateArticlesListCommand : IRequest
    {
        public int Amount { get; } = 1;
        public decimal PriceCalculator { get; } = 1;
    }
}
