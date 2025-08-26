using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class ImageValidator: AbstractValidator<Image>
{ 
    public ImageValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel Başlığını boş geçemezsin.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel Açıklmasını boş geçemezsin.");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Yolunu boş geçemezsin.");

        RuleFor(x => x.Title).MaximumLength(20).WithMessage("Maksimum 20 karakterden fazla girmeyiniz.");
    }
}