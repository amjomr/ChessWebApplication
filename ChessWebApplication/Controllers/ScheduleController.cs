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
        public int TimesPlayed = 2;
        int TotalGames(string[] teams)
        {
            int numberOfGames = 0;
            for (int initialGames = teams.Length - 1; initialGames > 0; initialGames--)
                numberOfGames += initialGames;
            numberOfGames = numberOfGames * TimesPlayed;
            return numberOfGames;
        }
        List<List<List<string>>> GenerateSchedule(string[] teams)
        {
            int numberOfGames = TotalGames(teams);
            string team1 = "";
            string team2 = "";
            List<string> game = new List<string>();
            List<List<List<string>>> ScheduleList = new List<List<List<string>>>();
            List<List<string>> FirstSchedule = new List<List<string>>();
            for (int i = 0; i < teams.Length; i++)
            {
                team1 = teams[1];
                game.Add(team1);
                for (int j = i + 1; j < teams.Length; j++)
                {
                    team2 = teams[j];
                    game.Add(team2);
                    FirstSchedule.Add(game);
                    game.RemoveAt(2);
                }
            }
            for (int n = 0; n < TimesPlayed; n++)
                ScheduleList.Add(FirstSchedule);

                return ScheduleList;
        }
       
        }
        public List<Schedule> GetScheduleList()
        {
            List<Schedule> result = new List<Schedule>();



            return result;
        }
        public ActionResult Index()
        {
            var schedule = from r in GetScheduleList()
                          select r;
            return View(schedule);
        }
        }



