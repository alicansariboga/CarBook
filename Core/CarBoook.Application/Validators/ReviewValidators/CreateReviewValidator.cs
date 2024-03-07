using CarBoook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Validators.ReviewValidators
{
	public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
	{
		public CreateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("En az 5 karakter olmalıdır.");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("En az 50 karakter olmalıdır.");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("En fazla 500 karakter olmalıdır.");
		}
	}
}
