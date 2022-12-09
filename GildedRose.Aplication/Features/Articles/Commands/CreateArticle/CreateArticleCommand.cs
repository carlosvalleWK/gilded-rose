using MediatR;

namespace GildedRose.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<int>
    {
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
        public bool AgedBrie { get; set; }
    }
}
