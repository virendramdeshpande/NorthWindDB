using CQRSFrameWork;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{

    public class GeographicalQueryHandler : IQueryHandler<GeographicalQuery, GeographicalQueryResult>

    {
        private readonly ICustomerRepository _CustomerRepository;

        public GeographicalQueryHandler(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        public GeographicalQueryResult Retrieve(GeographicalQuery query)
        {
            GeographicalQueryResult result = new GeographicalQueryResult();
            if (query.GetCountiesFlag ==true)
            {
                result.list = _CustomerRepository.getAllCountries();
            }
            else if(query.SearchByCountry)
            {
                result.list = _CustomerRepository.getAllCitiesOfTheCity(query.CountryName);
            }
            return result;
        }

       
    }
}
