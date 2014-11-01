using System;
using System.Collections.Generic;
using System.Web.Http;
using ActionFilters.Infrastructure;

namespace ActionFilters.Controllers.api
{
    public class ExampleController : ApiController
    {
        // GET: api/Example
        [UserConfirmedWebApiFilterAttribute]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}