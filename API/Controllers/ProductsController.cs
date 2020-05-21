using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }


        /*
        This is a synchronous method hence the thread that our request
        is executing will be blocked until this method execution is 
        completed. It will wait until the request to SQL has finished.
        There is no problem when the query is small but if the query is
        complex. It could take many seconds for execution.

        public ActionResult<List<Product>> GetProducts()
        {

            var products = _context.Products.ToList();

            return Ok(products);
        }

        To overcome this we make use of an asynchronous version. 
        The below method will delegate the query to fetch products from db
        This delege will obtain the data and store it in products but
        simultaneously the request would be processed.
        
        Asynchronous is mostly used with methods that have to fetch data
        from db.
        */
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

    }
}