using System;
using System.Collections.Generic;
using System.Linq;
using CustomerInquiry.Api.ViewModels;
using CustomerInquiry.Dal.Models;
using CustomerInquiry.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        /// <summary>
        /// Get customer info by customer id or email
        /// </summary>
        /// <param name="inquiry"></param>  
        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public ActionResult<Customer> GetCustomers([FromBody] Inquiry inquiry)
        {
            try
            {
                if (inquiry == null || (inquiry.CustomerId == null && string.IsNullOrEmpty(inquiry.Email)))
                {
                    return BadRequest("No inquiry criteria");
                }

                var customer = _customerService.GetCustomerInfo(inquiry.CustomerId, inquiry.Email);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}