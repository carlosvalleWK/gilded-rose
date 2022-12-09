using AutoMapper;
using GildedRose.Application.Contracts.Persistence;
using GildedRose.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GildedRose.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateArticleCommandHandler> _logger;

        public CreateArticleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateArticleCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleEntity = _mapper.Map<Article>(request);

            _unitOfWork.ArticleRepository.AddEntity(articleEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el registro de article");
            }

            _logger.LogInformation($"Article {articleEntity.Id} fue creado exitosamente");

            return articleEntity.Id;
        }
    }
}
