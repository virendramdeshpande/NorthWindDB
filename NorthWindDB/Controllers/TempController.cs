using CQRSFrameWork;
using QueryHandlers;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthWindDB.Controllers
{
    public class TempController : ApiController
    {

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public TempController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        // GET: api/Temp

        public IEnumerable<Customer> Get()
        {
            var query = new CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return result.Customers;
        }

        // GET: api/Temp/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Temp
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Temp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Temp/5
        public void Delete(int id)
        {
        }
    }
}
