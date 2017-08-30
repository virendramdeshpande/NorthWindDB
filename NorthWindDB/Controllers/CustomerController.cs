using CQRSFrameWork;
using Newtonsoft.Json;
using QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindDB.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomerController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var query = new CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return View(result.Customers);
        }


        public ActionResult GetAllCustomers()
        {
            var query = new CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return Json(result.Customers,JsonRequestBehavior.AllowGet);


        }

        public ActionResult getCustomerByName(string Name)
        {
            var query = new CustomerQuery();
            query.ContactName = Name;
            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return Json(result.Customers, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult getCustomerByCriteria(CustomerQuery customerQuery)
        {
            var query = new CustomerQuery();
            query.CompanyName = customerQuery.CompanyName;
            query.ContactName = customerQuery.ContactName;
            query.ContactTitle = customerQuery.ContactTitle;
            query.City = customerQuery.City;
            query.Country = customerQuery.Country;
            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public ActionResult getAllCitiesOfTheCity(string Name)
        {
            // GeographicalQueryResult
            var query = new GeographicalQuery();
            query.SearchByCountry = true;
            query.CountryName = Name;
            var result = _queryDispatcher.Dispatch<GeographicalQuery, GeographicalQueryResult>(query);
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public ActionResult getAllCounties()
        {
            // GeographicalQueryResult
            var query = new GeographicalQuery();
            query.GetCountiesFlag = true;           
            var result = _queryDispatcher.Dispatch<GeographicalQuery, GeographicalQueryResult>(query);
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public ActionResult React()
        {
            return View();


        }
        [NonAction]
        public ActionResult NonAction()
        {
            return View();


        }

        // GET: /Customer/sample
        public ActionResult sample()
        {
            var query = new CustomerQuery();

            var result = _queryDispatcher.Dispatch<CustomerQuery, CustomerQueryResult>(query);
            return View(result.Customers);
        }

    }
}