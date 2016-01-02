using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BBK.App.DataAccess;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BranchesController : Controller
    {
        // GET: api/branches
        [HttpGet("")]
        public IEnumerable<string> GetAllBranches()
        {
            return new string[] { "Balham", "Elephant and Castle" };
        }
    }
}
