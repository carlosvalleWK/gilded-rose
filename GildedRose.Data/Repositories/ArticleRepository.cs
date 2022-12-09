using GildedRose.Application.Contracts.Persistence;
using GildedRose.Domain;
using GildedRose.Infrastucture.Persistence;

namespace GildedRose.Infrastucture.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(InventoryDbContext context) : base(context)
        {
        }

    }
}
