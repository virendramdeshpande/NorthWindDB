using CQRSFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{
    public class GeographicalQueryResult : IQueryResult
    {
        public List<string> list { get; set; }
    }
}
