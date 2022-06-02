using AutoMapper;
using Books.Dto;
using Books.Interfaces;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StanAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class CustomerController: BaseApiController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCustomerDto>>> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetCustomersAsync();
                var mappedEntities = _mapper.Map<IEnumerable<GetCustomerDto>>(customers);

                return Ok(mappedEntities);
            }
            catch (Exception)
            {
                return BadRequest("rrgvr");

            }
        }
        [HttpGet("{username}")]

        public async Task<ActionResult<GetCustomerDto>> GetCustomer(string username)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByUsernameAsync(username);

                return _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception)
            {
                return BadRequest("rrgvr");

            }
        }
    }
}
