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
    public class ValuesController : ControllerBase
    {
        private readonly HelloWorldKubeDBContext _dBContext;
        private readonly ILogger _logger;

        public ValuesController(HelloWorldKubeDBContext dBContext,
              ILogger<ValuesController> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            string requestorIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _dBContext.InvokeLogs.Add(new InvokeLog()
            {
                ServerHostName = Environment.MachineName,
                InvokeTime = DateTime.UtcNow,
                RequestorHostName = $"{ requestorIP} ( { ResolveRequestorHost() })"
            });
            _dBContext.SaveChangesAsync();
            string ResolveRequestorHost()
            {
                string hostName = string.Empty;
                try
                {

                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "");
                }
                return hostName;
            }
            return new string[] { "Hello World from API",
                  Environment.MachineName, DateTime.Now.ToLongTimeString() };
        }

        // GET api/values/5
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
