using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(w => w.WriterSurName).NotEmpty().WithMessage("Yazar soyadı açıklaması boş geçilemez.");
            RuleFor(w => w.WriterAbout).NotEmpty().WithMessage(" Yazar hakkında kısmı boş geçilemez.");
            RuleFor(w => w.WriterAbout).Must(AboutContains).WithMessage("Yazar hakkında kısmı 'A' harfi içermelidir.");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Yazar adı minimum 2 karakter olmalıdır.");
            RuleFor(w => w.WriterSurName).MaximumLength(50).WithMessage("Yazar soyadı adı maximum 50 karakter olabilir.");
            RuleFor(w => w.WriterAbout).Must(AboutContains).WithMessage("Yazar hakkında kısmı 'A' harfi içermelidir.");
            RuleFor(w => w.WriterTitle).NotEmpty().WithMessage("Yazar unvan boş geçilemez.");

        }

        private bool AboutContains(string arg)
        {
            return arg.ToLower().Contains("a");
            
        }

    }
}
