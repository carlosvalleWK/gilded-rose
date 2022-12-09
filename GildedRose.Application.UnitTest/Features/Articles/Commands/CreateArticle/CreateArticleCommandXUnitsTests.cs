using AutoMapper;
using GildedRose.Application.Features.Articles.Commands.CreateArticle;
using GildedRose.Application.Mappings;
using GildedRose.Application.UnitTests.Mocks;
using GildedRose.Infrastucture.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace GildedRose.Application.UnitTests.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandXUnitsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateArticleCommandHandler>> _logger;

        public CreateArticleCommandXUnitsTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<CreateArticleCommandHandler>>();

            MockArticleRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task CreateArticleCommand_InputArticle_ReturnsNumber()
        {
            var articleInput = new CreateArticleCommand()
            {
                SellIn = 1,
                Quality = 10,
                Price = 3.5m,
                AgedBrie = true
            };
            var handler = new CreateArticleCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(articleInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }
    }
}
