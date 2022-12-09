using GildedRose.Domain;

namespace GildedRose.Application.Contracts.Persistence
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
    }
}
