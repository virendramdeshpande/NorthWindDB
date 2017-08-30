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
    public class SampleController : ApiController
    {

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public SampleController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var query = new CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return result.Customers;
        }
    }
}
