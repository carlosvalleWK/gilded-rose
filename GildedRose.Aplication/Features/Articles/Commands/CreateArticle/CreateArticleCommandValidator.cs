using FluentValidation;

namespace GildedRose.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(article => article.Quality)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(50);
        }
    }
}
