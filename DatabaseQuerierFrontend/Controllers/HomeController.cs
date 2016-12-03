using DatabaseQuerierFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseQuerierFrontend.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            var data = new List<Person>();
            using(var context = new Database1Entities())
            {
                string name = formCollection["FirstName"];
                var people = context.People.Where(p => p.FirstName == name);
                data = people.ToList();
            }
            //return RedirectToAction("Index");
            return View("SearchResults", data);
        }

        public ActionResult AdvancedSearch()
        {
            var criteria = new AdvancedSearchCriteria();
            return View(criteria);
        }

        [HttpPost]
        public ActionResult AdvancedSearch(AdvancedSearchCriteria criteria)
        {
            var result = new AdvancedSearchResults();
            using (var context = new Database1Entities())
            {
                var people = context.People.AsQueryable();
                if (!string.IsNullOrEmpty(criteria.FirstName))
                    people = people.Where(p => p.FirstName == criteria.FirstName);

                if (!string.IsNullOrEmpty(criteria.LastName))
                    people = people.Where(p => p.LastName == criteria.LastName);

                result.People = people.ToList();
            }

            result.HeaderText = $"{result.People.Count()} records found";
            return View("AdvancedSearchResults", result);
            // return RedirectToAction(nameof(AdvancedSearch));
        }
    }
}