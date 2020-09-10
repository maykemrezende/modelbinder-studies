using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelBindStudies.Attributes;
using ModelBindStudies.Models;

namespace ModelBindStudies.Controllers
{
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Teste([FromClaim] dynamic postTest)
        {
            var teste = (PostTest)postTest;
            var dataObject = teste.Data;
            return Ok();
        }
    }
}
