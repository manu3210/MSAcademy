using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace CarRentalsWebAPI.UnitTests.Validations
{
    public class CarValidatorTests
    {
        private readonly CarValidator _validator;
        public CarValidatorTests()
        {
            _validator = new CarValidator();
        }

        [Fact]
        public void CarValidator_WhenTransmitionIsInEnum_ShouldNotHaveError()
        {
            var model = new CarDto { Transmition = CarRentals.Enum.Transmition.Manual };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Transmition);
        }

        [Fact]
        public void CarValidator_WhenDoorsIsBetween1And5_ShouldNotHaveError()
        {
            var model = new CarDto { Doors = 4 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Doors);
        }

        [Fact]
        public void CarValidator_WhenDoorsIsNotBetween1And5_ShouldHaveError()
        {
            var model = new CarDto { Doors = 8 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Doors);
        }

        [Fact]
        public void CarValidator_WhenModelIsNull_ShouldHaveError()
        {
            var model = new CarDto { Model = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Model);
        }

        [Fact]
        public void CarValidator_WhenModelHasMoreThan20Characters_ShouldHaveError()
        {
            var model = new CarDto { Model = "123456789012345678901" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Model);
        }

        [Fact]
        public void CarValidator_WhenModelHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var model = new CarDto { Model = "1234" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Model);
        }
        /*********************************************************************************/

        [Fact]
        public void CarValidator_WhenColorIsNull_ShouldHaveError()
        {
            var model = new CarDto { Color = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Color);
        }

        [Fact]
        public void CarValidator_WhenColorHasMoreThan20Characters_ShouldHaveError()
        {
            var model = new CarDto { Color = "123456789012345678901" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Color);
        }

        [Fact]
        public void CarValidator_WhenColorHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var model = new CarDto { Color = "1234" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Color);
        }
    }
}
