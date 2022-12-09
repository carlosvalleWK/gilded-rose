using AutoMapper;
using GildedRose.Application.Features.Articles.Commands.UpdateArticlesList;
using GildedRose.Application.Mappings;
using GildedRose.Application.UnitTests.Mocks;
using GildedRose.Infrastucture.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace GildedRose.Application.UnitTests.Features.Articles.Commands.UpdateArticlesList
{
    public class UpdateArticlesListCommandXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateArticlesListCommandHandler>> _logger;

        public UpdateArticlesListCommandXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<UpdateArticlesListCommandHandler>>();

            MockArticleRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_ReturnsUnit()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(articleInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }

        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_CorrectQuality()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList.ShouldNotContain(x => x.Quality < 0);
            articlesList.ShouldNotContain(x => x.Quality > 50);
        }

        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_DoubleDegradation()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList[2].Quality.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_IncreaseQuality()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList[3].Quality.ShouldBeEquivalentTo(50);
        }
        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_ReduceQuality()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList[4].Quality.ShouldBeEquivalentTo(1);
        }
        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_ReduceSellIn()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList[5].SellIn.ShouldBeEquivalentTo(0);
        }
        [Fact]
        public async Task UpdateArticleCommand_UpdateArticleList_CalculatePrice()
        {
            var articleInput = new UpdateArticlesListCommand()
            {

            };
            var handler = new UpdateArticlesListCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            await handler.Handle(articleInput, CancellationToken.None);

            var articlesList = await _unitOfWork.Object.ArticleRepository.GetAllAsync();

            articlesList[3].Price.ShouldBeEquivalentTo(49m);
        }
    }
}
