using CQRSFrameWork;
using QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthWindDB.Controllers
{
    public class customerInfoController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public customerInfoController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public List<Repositories.Customer> GetList()
        {
            var query = new QueryHandlers.CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return result.Customers;
            
        }
    }
}
