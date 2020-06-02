using AfiCustomerApi.Data.Models;
using AfiCustomerApi.Services.Services;
using AutoFixture;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AfiCustomerApiServicesTests.Services
{ 
    public class AfiCustomerValidationServiceTest
    {
        public readonly Fixture _fixture;
        public readonly IAfiCustomerValidationService _validationService;
        public AfiCustomerValidationServiceTest()
        {
            _fixture = new Fixture();
            _validationService = new AfiCustomerValidationService();
        }

        [Fact]
        public async Task ValidateCustomerWhenCustomerhasNullSurname_ReturnsFalse()
        {
            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.SurName = null;

            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
            
        }
        [Fact]
        public async Task ValidateCustomerWhenCustomerhasNullFirstname_ReturnsFalse()
        {
            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.FirstName = null;

            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
        }
        [Fact]
        public async Task ValidateCustomerWhenCustomerhasNullEmailandDob_ReturnsFalse()
        {
            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.Email = null;
            customer.Dob = null;

            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
        }
        [Theory]
        [InlineData("AD-23454")]
        [InlineData("12-234543")]
        [InlineData("BC-23A543")]
        [InlineData("BCS-13543")]
        [InlineData("BCS-13$43")]
        [InlineData("BC-13.432")]
        [InlineData("BC-13-432")]
        public async Task ValidateCustomerWhenCustomerhasInvalidPolicyReferenceNumber_returnsfalse(string invalidPolicy)
        {
            _fixture.Customize<AfiCustomer>(c =>
               c.With(p => p.SurName, "Murphy")
               .With(p => p.FirstName, "Richard")
               .With(p => p.Dob, DateTime.Now)
               .With(p => p.AfiCustomerID, 1)
               .With(p => p.PolicyReferenceNumber, "AD-234543")
               .With(p=>p.Email,"sfdg@sf.co.uk"));

            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.PolicyReferenceNumber = invalidPolicy;
            customer.Dob = null;
            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
        }

        [Theory]
        [InlineData("AD-234543")]
        [InlineData("XC-234543")]
        [InlineData("MD-456543")]
        public async Task ValidateCustomerWhenCustomerhasValidPolicyReferenceNumber_returnstrue(string validPolicy)
        {
            _fixture.Customize<AfiCustomer>(c =>
               c.With(p => p.SurName, "Murphy")
               .With(p => p.FirstName, "Richard")
               .With(p => p.Dob, DateTime.Now)
               .With(p => p.AfiCustomerID, 1)
               .With(p => p.PolicyReferenceNumber, "AD-234543")
               .With(p => p.Email, "sfdg@sf.co.uk"));

            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.PolicyReferenceNumber = validPolicy;
            customer.Dob = null;
            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.True(result);
        }

        [Theory]
        [InlineData("df@df.com")]
        [InlineData("dfgh@df.co.nz")]
        [InlineData("dfgh@d.co.uk")]
        [InlineData("dfgh@d.com")]
        [InlineData("dfgh@dsdsd.co")]
        [InlineData("a234@dsdsd.co")]
        [InlineData("1234@dsd.co.uk")]
        public async Task ValidateCustomerWhenCustomerhasInValidEmail_returnsfalse(string inValidEmail)
        {
            _fixture.Customize<AfiCustomer>(c =>
               c.With(p => p.SurName, "Murphy")
               .With(p => p.FirstName, "Richard")
               .With(p => p.Dob, DateTime.Now)
               .With(p => p.AfiCustomerID, 1)
               .With(p => p.PolicyReferenceNumber, "AD-234543")
               .With(p => p.Email, "sfdg@sf.co.uk"));

            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.Email = inValidEmail;
            customer.Dob = null;
            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
        }

        [Theory]
        [InlineData("dfer@df.com")]
        [InlineData("dfgh@df.co.uk")]
        [InlineData("dfgh@d1.co.uk")]
        [InlineData("d23444@12.com")]
        [InlineData("er45465656@wer2.com")]
        [InlineData("afgh@dsdsd.com")]
        [InlineData("v234@dsd.co.uk")]
        public async Task ValidateCustomerWhenCustomerhasValidEmail_returnstrue(string validEmail)
        {
            _fixture.Customize<AfiCustomer>(c =>
               c.With(p => p.SurName, "Murphy")
               .With(p => p.FirstName, "Richard")
               .With(p => p.Dob, DateTime.Now)
               .With(p => p.AfiCustomerID, 1)
               .With(p => p.PolicyReferenceNumber, "AD-234543")
               .With(p => p.Email, "sfdg@sf.co.uk"));

            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.Email = validEmail;
            customer.Dob = null;
            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.True(result);
        }

        public static object[][] invalidDates = {
        new Object[] { new DateTime(2005,12,31) },
        new Object[] { new DateTime(2008,12,31) },
        new Object[] { new DateTime(2010,12,31) }
        };

        [Theory, MemberData(nameof(invalidDates))]
        public async Task ValidateCustomerWhenCustomerAgeIsLessThan18_returnsfalse(DateTime dob)
        {
            _fixture.Customize<AfiCustomer>(c =>
               c.With(p => p.SurName, "Murphy")
               .With(p => p.FirstName, "Richard")
               .With(p => p.Dob, DateTime.Now)
               .With(p => p.AfiCustomerID, 1)
               .With(p => p.PolicyReferenceNumber, "AD-234543")
               .With(p => p.Email, "sfdg@sf.co.uk"));

            AfiCustomer customer = _fixture.Create<AfiCustomer>();
            customer.Email = null;
            customer.Dob = dob;
            var result = await _validationService.ValidateCustomerEntity(customer);

            Assert.False(result);
        }
    }
}
