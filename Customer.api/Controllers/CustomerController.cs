using Customer.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDbContext _db;

        List<CustomerModel> _customers= new List<CustomerModel>();
        CustomerModel _customer= new CustomerModel();
        public CustomerController(CustomerDbContext db)
        {
            _db= db;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerModel> GetCustomers()
        {
            _customers=_db.customers.ToList();
            return _customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>>  Get(int id)
        {
            _customer= await _db.customers.FindAsync(id);

            return _customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel obj)
        {
            await _db.customers.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public async Task<IActionResult> Update(CustomerModel obj)
        {
            _db.customers.Update(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _customer = await _db.customers.FindAsync(id);
            _db.customers.Remove(_customer);
           return Ok(); 
        }
    }
}
