using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace CarRentalsWebAPI.UnitTests.Validations
{
    public class RentalValidatorTests
    {
        private readonly RentalValidator _validator;
        public RentalValidatorTests()
        {
            _validator = new RentalValidator();
        }

        [Fact]
        public void RentalValidator_PriceLessThanZero_ShouldHaveError()
        {
            var model = new RentalDto() { Price = -10 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(r => r.Price);
        }

        [Fact]
        public void RentalValidator_PriceGreaterThanZero_ShouldNotHaveError()
        {
            var model = new RentalDto() { Price = 10 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(r => r.Price);
        }
    }
}
