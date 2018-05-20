using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Models.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("The name is required.");
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("The name must has the maximum of 50 characters.");
            RuleFor(c => c.DocumentNumber).NotEmpty().MaximumLength(14).WithMessage("Document number is required.");
            RuleFor(c => c.DocumentNumber).MaximumLength(14).WithMessage("Document number must has the maximum of 14 characters.");
            RuleFor(c => c.BirthDate).NotEmpty().WithMessage("Birth Date is required.");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(c => c.Address).MaximumLength(100).WithMessage("The name must has the maximum of 100 characters.");
            RuleFor(c => c.IsEmployed).NotEmpty().WithMessage("You should inform if the person is working or not.");
            When(c => c.IsEmployed, () =>
            {
                RuleFor(c => c.Income).NotEmpty().WithMessage("The person must has an income when is employed");
                RuleFor(c => c.Income).GreaterThan(0).WithMessage("The income must be greater than 0 when person is employed.");
            });
        }

       
    }
}
