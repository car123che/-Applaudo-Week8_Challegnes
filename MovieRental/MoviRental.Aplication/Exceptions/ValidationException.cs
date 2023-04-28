using FluentValidation.Results;
using System;

namespace MovieRental.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException(ValidationResult validationResult, string name)
            : base($"Validation Exception in: {name}, Erros: {string.Join(" | ", validationResult.Errors )}")
        {
            
        }
    }
}
