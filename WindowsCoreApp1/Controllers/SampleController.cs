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
            _logger.LogInformation("Information - Sample.Get called");
            _logger.LogInformation("Debug - Sample.Get called");
            _logger.LogTrace("Trace - Sample.Get called");
            _logger.LogWarning("Warning - Sample.Get called");
            _logger.LogError("Error - Sample.Get called");
            _logger.LogCritical("Critical - Sample.Get called");
            return ".Net 5 - Windows - App 1 - LogsAdded";
        }
    }
}
