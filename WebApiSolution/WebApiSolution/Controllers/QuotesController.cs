using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSolution.Data;
using WebApiSolution.Models;

namespace WebApiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {
            this.quotesDbContext = quotesDbContext;
        }

        // GET: api/QuotesNew
        [HttpGet]
        public IActionResult Get()
        {
            // return quotesDbContext.Quotes;
            return Ok(quotesDbContext.Quotes); // Will return 200 status code and the quotes
                                               // return BadRequest(); // Example of statuses
                                               // return StatusCode(200); // If C# doesn't have a status you can use this to get the integer of the error. ?? // Obv. this is bad design cuz we can't remember all
                                               // so microsoft made it easier to work with status codes.
                                               // return StatusCode(StatusCodes.Status200OK); // use these

        }

        // GET: api/QuotesNew/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("Does not exist!");
            }
            return Ok(quote);
        }

        // POST: api/QuotesNew
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/QuotesNew/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var entity = quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return NotFound("No record is found!");
            }
            else
            {
                entity.Title = quote.Title; // You have to add here whatever you want to change
                quotesDbContext.SaveChanges();
                return Ok("Updated Successfully!");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("Record does not exist!");
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Deleted!");
        }
    }
}
