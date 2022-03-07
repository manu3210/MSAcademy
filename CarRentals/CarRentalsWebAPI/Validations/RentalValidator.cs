using CarRentalsWebAPI.DTO;
using FluentValidation;

namespace CarRentalsWebAPI.Validations
{
    public class RentalValidator : AbstractValidator<RentalDto>
    {
        public RentalValidator()
        {
            RuleFor(r => r.Customer).SetValidator(new CustomerValidator());
            RuleFor(r => r.Car).SetValidator(new CarValidator());
            RuleFor(r => r.Price).NotNull().GreaterThan(0);
            RuleFor(r => r.Beginning).NotNull();
            RuleFor(r => r.End).NotNull();

        }
    }
}
