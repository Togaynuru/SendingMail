using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendingMail.Models.Validators
{
    public class EmailValidator: AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen Name kısmını doldurun..!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Boş bırakmayınız.");
            RuleFor(x => x.Name).MaximumLength(30);

            RuleFor(x => x.EmailAdress).NotNull().WithMessage("Boş Bırakılamaz.!");
            RuleFor(x => x.EmailAdress).EmailAddress().WithMessage("Lütfen doğru bir Mail adresi giriniz..!");

            RuleFor(x => x.Topic).MaximumLength(50);

            RuleFor(x => x.Comment).NotNull().WithMessage("Lütfen Mesaj bölümünü boş bırakmayınız.!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Sanırım bir yanlışlık oldu lütfen mesajınızı yazınız.!");
        }
    }
}
