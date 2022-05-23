using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
        private Context _context;

        public CustomerController (Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CustomerDetailsModel> Get()
        {
            return _context.CustomerDetails.ToList();
        }
        
        [HttpGet("{CustomerId}")]
        public CustomerDetailsModel GetCustomer(int CustomerId)
        {
            var customer = _context.CustomerDetails.Where(o=>o.CustomerId == CustomerId).SingleOrDefault();
            return customer; 

        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDetailsModel CustomerDetails)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Model");
            }
            _context.CustomerDetails.Add(CustomerDetails);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var customer = await _context.CustomerDetails.FindAsync(Id);
            if(customer==null)
            {
                return NotFound();
            }

            _context.CustomerDetails.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
