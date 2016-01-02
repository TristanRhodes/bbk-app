using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BBK.App.DataAccess;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        // GET: api/customers
        [HttpGet("")]
        public IEnumerable<string> GetCustomers()
        {
            return new string[] { "Customer1", "Customer2" };
        }
    }
}
