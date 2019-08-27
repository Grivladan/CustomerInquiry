using CustomerInquiry.Api.ViewModels;
using CustomerInquiry.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
using CustomerInquiry.Dal.Models;
using CustomerInquiry.Api.Controllers;

namespace CustomerInquiry.Tests
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _mockCustomerService;

        public CustomerControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
        }

        [Fact]
        public void GetCustomersInfo_CorrectInquiry_ShouldReturnCustomerInfo()
        {
            int customerId = 123456;
            string email = "user @domain.com";
            var inquiry = new Inquiry
            {
                CustomerId = customerId,
                Email = email
            };
            // Arrange
            _mockCustomerService.Setup(service => service.GetCustomerInfo(inquiry.CustomerId, inquiry.Email))
                .Returns(GetTestCustomer());
            var controller = new CustomerController(_mockCustomerService.Object);

            // Act
            var result = controller.GetCustomers(inquiry);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<Customer>(viewResult.Value);
            Assert.Equal(customerId, model.Id);
            Assert.Equal(email, model.Email);
        }

        [Fact]
        public void GetCustomersInfo_EmptyInquiry_ShouldReturnBadRequest()
        {
            var inquiry = new Inquiry
            {
                CustomerId = null,
                Email = null
            };
            // Arrange
            _mockCustomerService.Setup(service => service.GetCustomerInfo(inquiry.CustomerId, inquiry.Email))
                .Returns(GetTestCustomer());
            var controller = new CustomerController(_mockCustomerService.Object);

            // Act
            var result = controller.GetCustomers(inquiry);

            // Assert

            var viewResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("No inquiry criteria", viewResult.Value);          
        }

        [Fact]
        public void GetCustomersInfo_InquiryWithNotExistingCustomer_ShouldReturnNotFound()
        {
            var inquiry = new Inquiry
            {
                CustomerId = 12,
                Email = null
            };
            // Arrange
            _mockCustomerService.Setup(service => service.GetCustomerInfo(inquiry.CustomerId, inquiry.Email))
                .Returns((Customer)null);
            var controller = new CustomerController(_mockCustomerService.Object);

            // Act
            var result = controller.GetCustomers(inquiry);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        private Customer GetTestCustomer()
        {
            return new Customer
            {
                Id = 123456,
                Name = "Firstname LastName",
                Email = "user @domain.com",
                PhoneNo = 0123456789,
                Transactions = new List<Transaction>
                {
                    new Transaction()
                    {
                        Id = 1,
                        Amount = 1234.56M,
                        CurrencyCode = "USD",
                        Status = Status.Success
                    }
                }
            };     
        }
    }
}
