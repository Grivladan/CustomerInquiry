using System;
using System.Collections.Generic;
using System.Linq;
using CustomerInquiry.Api.ViewModels;
using CustomerInquiry.Dal.Models;
using CustomerInquiry.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers(Inquiry inquiry)
        {
            try
            {
                if (inquiry == null || (inquiry.CustomerId == null && string.IsNullOrEmpty(inquiry.Email)))
                {
                    return BadRequest("No inquiry criteria");
                }

                var customers = _customerService.GetCustomersInfo(inquiry.CustomerId, inquiry.Email);

                if (!customers.Any())
                {
                    return NotFound();
                }

                return customers.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}