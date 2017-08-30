using CQRSFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{
    public class CustomerQuery: IQuery
    {
        public string CompanyName { set;get;}
        public string ContactName { set; get; }
        public string ContactTitle { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
       


    }
}
