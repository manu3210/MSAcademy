using CarRentalsWebAPI.DTO;
using FluentValidation;

namespace CarRentalsWebAPI.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Phone).NotNull().MaximumLength(20);
            RuleFor(c => c.FirstName).NotNull().MaximumLength(20);
            RuleFor(c => c.LastName).NotNull().MaximumLength(20);
            RuleFor(c => c.Province).NotNull().MaximumLength(20);
            RuleFor(c => c.City).NotNull().MaximumLength(20);
            RuleFor(c => c.Adress).NotNull().MaximumLength(20);
            RuleFor(c => c.Dni).NotNull().MaximumLength(20);
        }
    }
}
