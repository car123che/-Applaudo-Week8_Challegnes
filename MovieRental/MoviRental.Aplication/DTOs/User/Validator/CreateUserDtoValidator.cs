using FluentValidation;
using MovieRental.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.User.Validator
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .EmailAddress();

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Age)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .LessThan(100).WithMessage("{PropertyName} must be lesser than 100")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(p => p.Role)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .LessThan(3).WithMessage("{PropertyName} must be lesser than 3")
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
