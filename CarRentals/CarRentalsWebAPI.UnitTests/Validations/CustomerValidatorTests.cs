using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace CarRentalsWebAPI.UnitTests.Validations
{
    public class CustomerValidatorTests
    {
        private readonly CustomerValidator _validator;
        private readonly CustomerDto _nullCustomer;
        private readonly CustomerDto _validCustomer;
        private readonly CustomerDto _invalidCustomer;
        public CustomerValidatorTests()
        {
            _validator = new CustomerValidator();
            _nullCustomer = new CustomerDto
            {
                Adress = null,
                City = null,
                Dni = null,
                FirstName = null,
                LastName = null,
                Phone = null,
                Province = null,
            };
            _validCustomer = new CustomerDto
            {
                Adress = "1234",
                City = "1234",
                Dni = "1234",
                FirstName = "1234",
                LastName = "1234",
                Phone = "1234",
                Province = "1234",
            };

            _invalidCustomer = new CustomerDto
            {
                Adress = "123456789012345678901",
                City = "123456789012345678901",
                Dni = "123456789012345678901",
                FirstName = "123456789012345678901",
                LastName = "123456789012345678901",
                Phone = "123456789012345678901",
                Province = "123456789012345678901",
            };
        }

        [Fact]
        public void CustomerValidator_WhenAdressIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Adress);
        }

        [Fact]
        public void CustomerValidator_WhenAdressHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Adress);
        }

        [Fact]
        public void CustomerValidator_WhenAdressHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.Adress);
        }

        [Fact]
        public void CustomerValidator_WhenCityIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.City);
        }

        [Fact]
        public void CustomerValidator_WhenCityHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.City);
        }

        [Fact]
        public void CustomerValidator_WhenCityHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.City);
        }

        [Fact]
        public void CustomerValidator_WhenDniIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Dni);
        }

        [Fact]
        public void CustomerValidator_WhenDniHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Dni);
        }

        [Fact]
        public void CustomerValidator_WhenDniHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.Dni);
        }

        [Fact]
        public void CustomerValidator_WhenFirstNameIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.FirstName);
        }

        [Fact]
        public void CustomerValidator_WhenFirstNameHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.FirstName);
        }

        [Fact]
        public void CustomerValidator_WhenFirstNameHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.FirstName);
        }

        [Fact]
        public void CustomerValidator_WhenLastNameIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.LastName);
        }

        [Fact]
        public void CustomerValidator_WhenLastNameHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.LastName);
        }

        [Fact]
        public void CustomerValidator_WhenLastNameHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.LastName);
        }

        [Fact]
        public void CustomerValidator_WhenPhoneIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Phone);
        }

        [Fact]
        public void CustomerValidator_WhenPhoneHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Phone);
        }

        [Fact]
        public void CustomerValidator_WhenPhoneHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.Phone);
        }

        [Fact]
        public void CustomerValidator_WhenProvinceIsNull_ShouldHaveError()
        {
            var result = _validator.TestValidate(_nullCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Province);
        }

        [Fact]
        public void CustomerValidator_WhenProvinceHasMoreThan20Characters_ShouldHaveError()
        {
            var result = _validator.TestValidate(_invalidCustomer);
            result.ShouldHaveValidationErrorFor(c => c.Province);
        }

        [Fact]
        public void CustomerValidator_WhenProvinceHasLessThan20CharactersAndIsNotNull_ShouldNotHaveError()
        {
            var result = _validator.TestValidate(_validCustomer);
            result.ShouldNotHaveValidationErrorFor(c => c.Province);
        }

    }
}
