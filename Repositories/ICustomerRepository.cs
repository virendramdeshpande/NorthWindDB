using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> FetchAll();
        List<Customer> getCustomerByName(string Name);
        List<string> getAllCountries();
        List<string> getAllCitiesOfTheCity(string Name);
        List<Customer> getCustomerByCriteria(string CompanyName, 
            string ContactName,
            string ContactTitle,
            string City, string Country
            );
        IQueryable<Customer> Query { get; }
        void Add(Customer entity);
        void Delete(Customer entity);
        void Save();


    }
}
