using FluentValidation;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Validators
{
    public class MaterialValidator : AbstractValidator<MaterialVM>
    {
        public MaterialValidator()
        {
            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.")
                .MaximumLength(250).WithMessage("Açıklama alanı en fazla 250 karakter olabilir.");

            RuleFor(m => m.MaterialType)
                .NotEmpty().WithMessage("Materyal türü seçilmelidir.")
                .IsInEnum().WithMessage("Materyal türü açılır kutuda yer alan verilerden seçilmelidir.");
        }
    }
}
