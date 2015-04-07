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
        public ActionResult Index(SearchModel search)
        {
            if(search.HasCriteria())
            {
                var presidents = PresidentRepository.GetAllPresidents();
                presidents = presidents.Where(search.ToExpression());
                search.SearchResults = presidents;
            }

            return View(search);
        }
    }
}