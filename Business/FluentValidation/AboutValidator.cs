using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(a => a.AboutDetails1).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(a => a.AboutDetails2).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
