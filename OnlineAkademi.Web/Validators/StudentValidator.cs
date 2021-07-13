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
    public class StudentValidator : AbstractValidator<StudentVM>
    {
        public StudentValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.")
                .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olablir.");
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Eposta adresi boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Eposta adresi en fazla 150 karakter olablir.")
                .EmailAddress().WithMessage("Eposta adresi uygun formatta değil.");
            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("Parola boş bırakılamaz.")
                .MaximumLength(4).WithMessage("Parola en fazla 4 karakter olablir.");

            RuleFor(s => s.PasswordConfirm)
                .NotEmpty().WithMessage("Parola tekrar alanı boş bırakılamaz.")
                .MaximumLength(4).WithMessage("Parola tekrar alanı en fazla 4 karakter olablir.")
                .Equal(c => c.Password).WithMessage("Parola ve parola tekrar alanları eşleşmiyor.");           

            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("İsim boş bırakılamaz.")
                .MaximumLength(30).WithMessage("İsim en fazla 300 karakter olablir.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Soyisim boş bırakılamaz.")
                .MaximumLength(30).WithMessage("İsim en fazla 30 karakter olablir.");
            
            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage("Eğitmenin cinsiyeti boş bırakılamaz.");

            RuleFor(c => c.Age)
                .NotEmpty().WithMessage("Eğitmen yaşı boş bırakılamaz.");
        }
    }
}
