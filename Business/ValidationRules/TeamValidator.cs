using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class TeamValidator:AbstractValidator<Team>
{
    public TeamValidator()
    {
        RuleFor(x => x.PersonName).NotEmpty().WithMessage("İsmi bş geçemezsin.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Görev kısmını boş geçemezsin.");
        RuleFor(x => x.Image).NotEmpty().WithMessage("Resim kısmını boş geçemezsin.");
        RuleFor(X => X.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla girmeyiniz.");
    }
}