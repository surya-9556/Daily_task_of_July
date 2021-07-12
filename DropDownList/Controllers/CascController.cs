using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownList.Controllers
{
    public class CascController : Controller
    {
        // GET: Casc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCountry()
        {
            var country = new List<string>();
            country.Add("India");
            country.Add("USA");
            country.Add("UK");
            return Json(country, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetStates(string country)
        {
            var States = new List<string>();
            switch(country.ToLower())
            {
                case "india":
                    States.Add("Andhra Pradesh");
                    States.Add("Tamil Nadu");
                    break;
                case "usa":
                    States.Add("California");
                    States.Add("New York");
                    break;
                case "uk":
                    States.Add("England");
                    States.Add("North Island");
                    break;
                default:
                    break;
            }
            return Json(States, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCity(string state)
        {
            var Cities = new List<string>();
            switch (state.ToLower())
            {
                case "andhra pradesh":
                    Cities.Add("Kadapa");
                    Cities.Add("Nellore");
                    break;
                case "tamil nadu":
                    Cities.Add("Avadi");
                    Cities.Add("Madhurai");
                    break;
                case "california":
                    Cities.Add("Los Angeles");
                    Cities.Add("San Francisco");
                    break;
                case "new york":
                    Cities.Add("Buffalo");
                    Cities.Add("Brooklyn");
                    break;
                case "england":
                    Cities.Add("London");
                    Cities.Add("Liver Pool");
                    break;
                case "north island":
                    Cities.Add("Derry");
                    Cities.Add("Belfest");
                    break;
                default:
                    break;
            }
            return Json(Cities, JsonRequestBehavior.AllowGet);
        }
    }
}