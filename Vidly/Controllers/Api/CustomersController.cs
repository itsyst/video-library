using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetTodoItems()
        {
            return await _context.Customers
                .Select(customer => Mapper.Map<Customer, CustomerDto>(customer))
                .ToListAsync().ConfigureAwait(true);
        }

        // GET /api/customers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id).ConfigureAwait(true);

            if (customer == null)
            {
                return NotFound();
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
           
            _context.Customers.Add(customer);
           
            await _context.SaveChangesAsync().ConfigureAwait(true);

            customerDto.Id = customer.Id;

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);

        }


        // DELETE /api/customers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id).ConfigureAwait(true);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }


        // PUT /api/customers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            var customer = await _context.Customers.FindAsync(id).ConfigureAwait(true);
            if (customer == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customer);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (DbUpdateConcurrencyException) when (!CustomerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool CustomerExists(int id) =>
            _context.Customers.Any(e => e.Id == id);

    }
}