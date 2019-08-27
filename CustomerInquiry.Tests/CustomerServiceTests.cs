using CustomerInquiry.Dal;
using CustomerInquiry.Logic.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using CustomerInquiry.Dal.Models;
using Xunit;

namespace CustomerInquiry.Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;

        public CustomerServiceTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void GetCustomersInfo_ExistingCustomerId_ShouldReturnCustomerInfo()
        {
            int customerId = 123456;
            string email = "user @domain.com";
            _mockCustomerRepository.Setup(repository => repository.GetAll()).Returns(GetTestCustomers());
            // Arrange
            var service = new CustomerService(_mockCustomerRepository.Object);

            // Act
            var result = service.GetCustomerInfo(customerId, email);

            Assert.Equal(customerId, result.Id);
            Assert.Equal(email, result.Email);
            // Assert

        }

        [Fact]
        public void GetCustomersInfo_NotExistingCustomerId_ShouldReturnEmptyList()
        {
            int customerId = 1111111;
            string email = "user @domain.com";

            // Arrange
            _mockCustomerRepository.Setup(repository => repository.GetAll()).Returns(GetTestCustomers());
            var service = new CustomerService(_mockCustomerRepository.Object);

            // Act
            var result = service.GetCustomerInfo(customerId, email);
            Assert.Null(result);

            // Assert
            
        }

        private IQueryable<Customer> GetTestCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
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
                },
                  new Customer
                {
                    Id = 1,
                    Name = "Firstname1 LastName1",
                    Email = "user1 @domain.com",
                    PhoneNo = 111111,
                },
            };

            return customers.AsQueryable();
        }
    }
}
