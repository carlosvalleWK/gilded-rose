using GildedRose.Domain.Common;

namespace GildedRose.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();

        public IArticleRepository ArticleRepository { get; }
    }
}
