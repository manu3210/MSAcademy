using CarRentalsWebAPI.DTO;
using FluentValidation;

namespace CarRentalsWebAPI.Validations
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(c => c.Brand).SetValidator(new BrandValidator()).NotNull();
            RuleFor(c => c.Transmition).IsInEnum().NotNull();
            RuleFor(c => c.Doors).NotNull().ExclusiveBetween(1, 5);
            RuleFor(c => c.Model).NotNull().MaximumLength(20);
            RuleFor(c => c.IsRented).NotNull();
            RuleFor(c => c.Color).NotNull().MaximumLength(10);
        }
    }
}
