using CarBoook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("En az 5 karakter olmalıdır.");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("En az 50 karakter olmalıdır.");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("En fazla 500 karakter olmalıdır.");
			RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Bu görsel URL adresini giriniz.").MinimumLength(10).WithMessage("En az 10 karakter uzunluğunda olmalıdır.").MaximumLength(200).WithMessage("En fazla 200 karakter uzunluğunda olmalıdır.") ;

		}
	}
}
