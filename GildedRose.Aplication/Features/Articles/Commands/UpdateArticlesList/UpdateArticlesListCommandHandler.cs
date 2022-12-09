using AutoMapper;
using GildedRose.Application.Contracts.Persistence;
using GildedRose.Application.Exceptions;
using GildedRose.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GildedRose.Application.Features.Articles.Commands.UpdateArticlesList
{
    public class UpdateArticlesListCommandHandler : IRequestHandler<UpdateArticlesListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateArticlesListCommandHandler> _logger;

        public UpdateArticlesListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateArticlesListCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateArticlesListCommand request, CancellationToken cancellationToken)
        {
            var articlesListToUpdate = await _unitOfWork.ArticleRepository.GetAllAsync();

            if (articlesListToUpdate.Count == 0)
            {
                _logger.LogError($"No hay articulos en el inventario");
                throw new NotFoundException(nameof(Article), articlesListToUpdate);
            }

            foreach (var article in articlesListToUpdate)
            {
                _mapper.Map(request, article, typeof(UpdateArticlesListCommand), typeof(Article));
                _unitOfWork.ArticleRepository.UpdateEntity(article);
            }

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando los articulos");

            return Unit.Value;
        }
    }
}
