using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChessWebApplication.Models;
using System.Data.Entity.Migrations;

namespace ChessWebApplication.Controllers
{

    public class TeamsController : Controller
    {
        private ChessDBEntities db = new ChessDBEntities();


        [NonAction]
        public List<Team> GetTeamList()
        {
            return new List<Team>
        {
            new Team
            {
                Id = 1,
                Name = "Warriors Team",
                TotalScore = 700
            },
            new Team
            {
                Id = 2,
                Name = "Vandals Team",
                TotalScore = 756
            },
            new Team
            {
                Id = 3,
                Name = "WSU Team",
                TotalScore = 984
            },
            new Team
            {
                Id = 4,
                Name = "WU Team",
                TotalScore = 454
            },
             new Team
            {
                Id = 5,
                Name = "FFF Team",
                TotalScore = 321
            },
              new Team
            {
                Id = 6,
                Name = "WRE Team",
                TotalScore = 275
            },
               new Team
            {
                Id = 7,
                Name = "YRE Team",
                TotalScore = 423
            },
                new Team
            {
                Id = 8,
                Name = "REW Team",
                TotalScore = 424
            },
                 new Team
            {
                Id = 9,
                Name = "SRE Team",
                TotalScore = 444
            },
                  new Team
            {
                Id = 10,
                Name = "EMS Team",
                TotalScore = 423
            },
        };
       }

        // GET: Teams
        public ActionResult Index()
        {
            var teams = from e in GetTeamList()
                        orderby e.TotalScore
                        select e;
            return View(teams);
            //return View(db.Team.ToList());    //THIS IS BROKEN
                                              //To get the page to display, comment out line 93 and un-comment 89-92
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
        // test ti push Amjad
        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Totalscore")] Team team)
        {

            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Totalscore")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
