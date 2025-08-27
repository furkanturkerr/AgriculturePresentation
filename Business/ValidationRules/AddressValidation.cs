using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class AddressValidation : AbstractValidator<Adress>
{
    public AddressValidation()
    {
        RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 boş geçilemez.");
        RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 boş geçilemez.");
        RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 boş geçilemez.");
        RuleFor(x => x.MapInfo).NotEmpty().NotEmpty().WithMessage("Hartita Bilgsi boş geçilemez.");
        RuleFor(x => x.MapInfo).MaximumLength(200).WithMessage("Hartita Bilgsi 200 karakterden fazla olamaz.");
    }
}