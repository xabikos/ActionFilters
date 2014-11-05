using System;
using System.Collections.Generic;
using System.Web.Http;
using ActionFilters.Infrastructure;

namespace ActionFilters.Controllers.api
{
    [UserConfirmedWebApiFilter]
    public class ExampleController : ApiController
    {
        // GET: api/Example
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}