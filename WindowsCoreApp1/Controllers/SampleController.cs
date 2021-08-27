using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsCoreApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return ".Net 5 - Windows Virtual Node - App 1";
        }
    }
}
