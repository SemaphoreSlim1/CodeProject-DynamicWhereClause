using DynamicWhereMvc.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicWhereMvc.Controllers
{
    public class SearchController : Controller
    {           
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SearchModel());
        }

        [HttpPost]
        public ActionResult Index(SearchModel search)
        {
            var presidents = PresidentRepository.GetAllPresidents();
            if (search.HasCriteria())
            {
                presidents = presidents.Where(search.ToExpression());
            }
            search.SearchResults = presidents;

            return View(search);
        }
    }
}