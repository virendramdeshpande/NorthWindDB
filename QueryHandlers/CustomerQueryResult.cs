using CQRSFrameWork;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{
    public class CustomerQueryResult : IQueryResult
    {
        public List<Customer> Customers { get; set; }
        public List<string> Counties { get; set; }
    }
}
