using FluentValidation;
using furboWebApi.Dtos;

namespace furboWebApi.Validators
{
    public class JugadorPostDtoValidator : AbstractValidator<JugadorPostDto>
    {
        public JugadorPostDtoValidator()
        {
            RuleFor(x => x.nombrepost)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Minimo 5 Caracteres");
            RuleFor(x => x.pospost)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("Largo maximo 50");
            RuleFor(x => x.valorpost)
                .NotEmpty();
            RuleFor(x => x.edadpost)
                .NotEmpty();
            RuleFor(x => x.id_clube)
                .NotEmpty();
        }
    }
}
