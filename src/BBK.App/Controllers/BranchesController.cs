using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BranchesController : Controller
    {
        // GET: api/core/branches
        [HttpGet("branches")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Balham", "Elephant and Castle" };
        }
    }
}
