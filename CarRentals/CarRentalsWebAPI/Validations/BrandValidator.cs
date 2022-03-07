using CarRentalsWebAPI.DTO;
using FluentValidation;

namespace CarRentalsWebAPI.Validations
{
    public class BrandValidator : AbstractValidator<BrandDto>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotNull().MaximumLength(20);
        }
    }
}
