using FluentValidation;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Validators
{
    public class CourseValidator:AbstractValidator<CourseVM>
    {
        public CourseValidator()
        {
            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("Kursun kategorisi seçilmedi.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kurs adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Kurs adı en fazla 150 karakter olmalıdır.");

            RuleFor(c => c.Duration)
                .NotEmpty().WithMessage("Kurs süresi boş bırakılamaz.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Kurs ücreti boş bırakılamaz.");

            RuleFor(c => c.Quota)
                .NotEmpty().WithMessage("Kursun maksimum kişi sayısı girilmelidir.");
        }
    }
}
