using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessWebApplication.Models;

namespace ChessWebApplication.Controllers
{
    public class ScheduleController : Controller
    {

        Schedule schedule = new Schedule();
        
        
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }
    }
}