using GildedRose.Application.Features.Articles.Commands.CreateArticle;
using GildedRose.Application.Features.Articles.Commands.UpdateArticlesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GildedRose.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateArticle")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateArticle([FromBody] CreateArticleCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut(Name = "UpdateArticlesList")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateArticlesList([FromBody] UpdateArticlesListCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
