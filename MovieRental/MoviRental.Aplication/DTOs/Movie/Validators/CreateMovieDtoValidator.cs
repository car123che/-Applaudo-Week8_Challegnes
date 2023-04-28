using FluentValidation;
using MovieRental.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.Movie.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
            RuleFor(p => p.Title)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Stock)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Poster)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.TrailerLink)
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.SalePrice)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
