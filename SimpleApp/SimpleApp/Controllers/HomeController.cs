using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View(HttpContext.Application["events"]);
            return View(GetTimeStamps());
        }

        [HttpPost]
        public ActionResult Index (Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            } else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            //return View(HttpContext.Application["events"]);
            return View(GetTimeStamps());
        }

        private List<string> GetTimeStamps()
        {
            return new List<string>
            {
                string.Format("Apptimestamp : {0}",
                    HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"]),
            };
        }
    }
}