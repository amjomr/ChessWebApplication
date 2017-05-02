using ChessWebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChessWebApplication.Controllers
{
    public class ResultsController : Controller
    {
        private ResultsDBContext db = new ResultsDBContext();

        [NonAction]
        public List<Results> GetResultsList()
        {
            return new List<Results>
        {
            new Results
            {
                WeekNum = 1,
                Winner = "Vandals",
                Loser = "WSU",
                WID = 2,
                LID = 3,
                WTotalScore = 25,
                LTotalScore = 10
            },
            new Results
            {
                WeekNum = 2,
                Winner = "WU",
                Loser = "Warriors",
                WID = 4,
                LID = 1,
                WTotalScore = 17,
                LTotalScore = 32
            },
            new Results
            {
                WeekNum = 3,
                Winner = "WSU",
                Loser = "WU",
                WID = 3,
                LID = 4,
                WTotalScore = 15,
                LTotalScore = 17
            }
            };
        }

        // GET: Results
        public ActionResult Index()
        {
            var results = from r in GetResultsList()
                          orderby r.WeekNum
                          select r;
            return View(results);
        }
    }
}