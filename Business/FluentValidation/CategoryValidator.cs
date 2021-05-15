using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez.");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori adı minimum 3 karakter olmalıdır.");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("Kategori adı maximum 20 karakter olabilir.");

        }
    }
}
