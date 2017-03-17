using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        //Searchtype and searchTerm I believe should be the 2 required params.



        
        [Route("/Search")]
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                List<Dictionary<string, string>> theJobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "Search By";
                ViewBag.jobs = theJobs;
                ViewBag.columns = ListController.columnChoices;
                return View("Index");

            }

            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //ViewBag.title = "Jobs with " + ": " + searchTerm;
                ViewBag.jobs = jobs;
                ViewBag.columns = ListController.columnChoices;

                return View("Index");
            }
        }
    }
}
