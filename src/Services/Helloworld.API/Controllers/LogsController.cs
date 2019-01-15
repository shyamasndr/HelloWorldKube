using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Helloworld.API.Data;
using System.Net;
using Microsoft.Extensions.Logging;
namespace Helloworld.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly HelloWorldKubeDBContext _dBContext;
        private readonly ILogger _logger;

        public LogsController(HelloWorldKubeDBContext dBContext,
              ILogger<ValuesController> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<InvokeLog>> Get()
        {
            return  _dBContext.InvokeLogs.ToList();
        }
    }
}