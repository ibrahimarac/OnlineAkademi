using FluentValidation;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Validators
{
    public class TrainerEditValidator : AbstractValidator<TrainerEditVM>
    {
        public TrainerEditValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.")
                .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olablir.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Eposta adresi boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Eposta adresi en fazla 150 karakter olablir.")
                .EmailAddress().WithMessage("Eposta adresi uygun formatta değil."); 
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("İsim boş bırakılamaz.")
                .MaximumLength(30).WithMessage("İsim en fazla 10 karakter olablir.");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Soyisim boş bırakılamaz.")
                .MaximumLength(30).WithMessage("İsim en fazla 10 karakter olablir.");
            RuleFor(c => c.TrainerType)
                .NotEmpty().WithMessage("Eğitmen türü boş bırakılamaz.");
            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage("Eğitmenin cinsiyeti boş bırakılamaz.");
            RuleFor(c => c.Experience)
                .NotEmpty().WithMessage("Deneyim alanı boş bırakılamaz.");
            RuleFor(c => c.Age)
                .NotEmpty().WithMessage("Eğitmen yaşı boş bırakılamaz.");
        }
    }
}
