using FluentValidation;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı soyadı boş geçilemez");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.Password).Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");
            RuleFor(p => p.Password).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermeli.");
            RuleFor(p => p.Password).Matches(@"[a-z]+").WithMessage("Şifre en az bir kicik harf içermeli.");
            RuleFor(p => p.Password).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermeli.");

            RuleFor(x => x.Password).Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");
            RuleFor(p => p.Password).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermeli.");
            RuleFor(p => p.Password).Matches(@"[a-z]+").WithMessage("Şifre en az bir kicik harf içermeli.");
            RuleFor(p => p.Password).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermeli.");
        }
    }
}
