using CQRSFrameWork;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers
{

    public class CustomerQueryHandler : IQueryHandler<CustomerQuery, CustomerQueryResult>
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerQueryHandler(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }



         CustomerQueryResult IQueryHandler<CustomerQuery, CustomerQueryResult>.Retrieve(CustomerQuery query)
        {
            CustomerQueryResult result = new CustomerQueryResult();
            // _CustomerRepository.Add(new Customer() { Country = "india" });


                result.Customers = _CustomerRepository.getCustomerByCriteria(query.CompanyName,
                    query.ContactName,
                    query.ContactTitle,
                    query.City,
                    query.Country);

           // result.Counties = _CustomerRepository.getAllCountries();

            return result;
        }
    }
}
