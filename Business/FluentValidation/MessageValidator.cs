using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adı boş geçilmez.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konu boş geçilmez.");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilmez.");
            RuleFor(m => m.Subject).MinimumLength(3).WithMessage("Konu minimum 3 karakter olmalıdır.");
            RuleFor(m => m.Subject).MaximumLength(100).WithMessage("Konu maximum 100 karakter olmalıdır. ");
           
            
        }
    }
}
