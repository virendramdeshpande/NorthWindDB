using CQRSFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{
    public class GeographicalQuery : IQuery
    {
        public bool GetCountiesFlag { set; get; }
        public bool SearchByCountry { set; get; }
        public string CountryName { set; get; }
    }
}
