using GildedRose.Application.Contracts.Persistence;
using GildedRose.Domain.Common;
using GildedRose.Infrastucture.Persistence;
using System.Collections;

namespace GildedRose.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly InventoryDbContext _context;


        private IArticleRepository _articleRepository;
        public IArticleRepository ArticleRepository => _articleRepository ??= new ArticleRepository(_context);

        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;
        }

        public InventoryDbContext InventoryDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if(_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repositories.Add(type, repositoryInstance);
               
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
