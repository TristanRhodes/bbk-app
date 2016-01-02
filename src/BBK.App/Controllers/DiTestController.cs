using BBK.App.DataAccess;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DiTestController : Controller
    {
        private IBasicDataAccess _dataAccess;

        public DiTestController(IBasicDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/DiTest/{message}
        [HttpGet("{message}")]
        public string EchoMessage(string message)
        {
            return _dataAccess.EchoMessage(message);
        }
    }
}
