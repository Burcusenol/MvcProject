using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserMail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz.");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu adı boş geçilemez.");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage("Konu minimum 3 karakter olmalıdır.");
            RuleFor(c => c.UserName).MinimumLength(3).WithMessage("Kullanıcı adı 3 karakter olmalıdır.");
            RuleFor(c => c.Subject).MaximumLength(0).WithMessage("Konu maximum 20 karakter olmalıdır.");

        }
    }
}
