using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        Entities DBcontext;
        public CustomerRepository()
        {
            DBcontext = new Entities();
        }
        public IQueryable<Customer> Query
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Customer entity)
        {
            DBcontext.Customers.Add(entity);
            DBcontext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            Customer deleteCustomer = DBcontext.Customers.Where(c => c.CustomerID == entity.CustomerID).First();
            DBcontext.Entry(deleteCustomer).State = EntityState.Deleted;
            DBcontext.SaveChanges();

            //DBcontext.Customers.se(entity);
            //DBcontext.SaveChanges();
        }

        public List<Customer> FetchAll()
        {
            DBcontext.Configuration.ProxyCreationEnabled = false;
            return  DBcontext.Customers.ToList();
        }

        public List<string> getAllCitiesOfTheCity(string Name)
        {
            DBcontext.Configuration.ProxyCreationEnabled = false;
            var List = DBcontext.Customers.Where(y=>y.Country == Name).Select(x => x.City).Distinct().ToList();
            return List;


            //return query.ToList();
        }

        public List<string> getAllCountries()
        {
            IQueryable<string> List = (from r in DBcontext.Customers

                                       select r.Country).Distinct().OrderBy(z => z); 


           return List.ToList();
        }

        public List<Customer> getCustomerByCriteria(string CompanyName, string ContactName, string ContactTitle, string City, string Country)
        {
            DBcontext.Configuration.ProxyCreationEnabled = false;
            IQueryable<Customer> query = DBcontext.Customers.Where(x => x.ContactName != null); 

            if (!string.IsNullOrEmpty(ContactName))
            {
                query = query.Where(x => x.ContactName.StartsWith(ContactName));
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                query = query.Where(x => x.CompanyName.StartsWith(CompanyName));
            }
            if (!string.IsNullOrEmpty(ContactTitle))
            {
                query = query.Where(x => x.ContactTitle.StartsWith(ContactTitle));
            }

            if (!string.IsNullOrEmpty(City))
            {
                query = query.Where(x =>x.City.StartsWith(City) );
            }
            if (!string.IsNullOrEmpty(Country))
            {
                query = query.Where(x => x.Country.StartsWith(Country));
                //list = query.ToList();
            }           

           

            return query.ToList();;





        }

        public List<Customer> getCustomerByName(string Name)
        {
            DBcontext.Configuration.ProxyCreationEnabled = false;
            return DBcontext.Customers.Where(x=>x.ContactName == Name).ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

      
           
    }
}
