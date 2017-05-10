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
        public int numberOfWeeks = 8;
        int TotalGames(string[] teams)
        {
            int numberOfGames = 0;
            for (int initialGames = teams.Length - 1; initialGames > 0; initialGames--)
                numberOfGames += initialGames;
            numberOfGames = numberOfGames * TimesPlayed;
            return numberOfGames;
        }
        public List<List<string>> GenerateGames(string[] teams)
        {
            int numberOfGames = TotalGames(teams);
            string team1;
            string team2;
            List<string> game = new List<string>();
            List<List<string>> ScheduleList = new List<List<string>>();
            for (int i = 0; i < teams.Length; i++)
            {
                team1 = teams[1];
                game.Add(team1);
                for (int j = i + 1; j < teams.Length; j++)
                {
                    team2 = teams[j];
                    game.Add(team2);
                    ScheduleList.Add(game);
                    game.RemoveAt(2);
                }
            }
                return ScheduleList;
        }
        public List<DateTime> TimeSchedule(DateTime StartDate)
        {
            List<DateTime> gameDays = new List<DateTime>();
            for (int i = 0; i < numberOfWeeks;)
            {
                gameDays.Add(StartDate.AddDays(i * 7));
            }
                return gameDays;
        }
        public Tuple<List<string>, DateTime>[] GenerateSchedule(string[] teams, DateTime StartDate)
        {
            Tuple<List<string>, DateTime>[] schedule = new Tuple<List<string>, DateTime>[TotalGames(teams)];
            List<DateTime> times = TimeSchedule(StartDate);
            List<List<string>> listOfGames = GenerateGames(teams);
            List<List<string>> games;
            Tuple<List<string>, DateTime> game;
            int count = 0;
            for (int i = 0; i < 6; i++)
            {

                    for (int j = 0; j < TotalGames(teams) / 6; j++)
                    {
                        game = Tuple.Create<List<string>, DateTime>(listOfGames[count], times[i]);
                    schedule[count] = game;
                        count++;
                    }
                    
                
            }

            return schedule;
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
}



