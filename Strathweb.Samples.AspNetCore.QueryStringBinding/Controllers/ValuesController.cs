using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Strathweb.Samples.AspNetCore.QueryStringBinding.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        //[SeparatedQueryString]
        public IEnumerable<string> Get([CommaSeparated]IEnumerable<string> values)
        {
            return values;
        }
    }
}
