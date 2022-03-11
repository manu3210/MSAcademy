using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace CarRentalsWebAPI.UnitTests.Validations
{
    public class BrandValidatorTests
    {
        private readonly BrandValidator _validator;
        public BrandValidatorTests()
        {
            _validator = new BrandValidator();
        }

        [Fact]
        public void BrandValidator_WhenBrandNameIsNull_ShouldHaveError()
        {
            var model = new BrandDto { BrandName = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(b => b.BrandName);
        }

        [Fact]
        public void BrandValidator_WhenBrandNameIsSpecified_ShouldNotHaveError()
        {
            var model = new BrandDto { BrandName = "Ford" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(b => b.BrandName);
        }
    }
}