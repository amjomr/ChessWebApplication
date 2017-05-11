using ChessWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace ChessWebApplication.Controllers
{
    public class ScheduleController : Controller
    {
        public int TimesPlayed = 2;
        public int numberOfWeeks = 8;
        public string[] teamList = new string[10];
        public string[] GenTeamList()
        {
            for (int x = 0; x < 10; x++)
                teamList[x] = "team" + x;
            return teamList;
        }
        int TotalGames(string[] teams)
        {
            int numberOfGames = 0;
            for (int initialGames = teams.Length - 1; initialGames > 0; initialGames--)
                numberOfGames += initialGames;
            numberOfGames = numberOfGames * TimesPlayed;
            return numberOfGames;
        }
        public List<string[]> GenerateGames(string[] teams)
        {
            int numberOfGames = TotalGames(teams);
            string team1;
            string team2;
            List<string> game = new List<string>();
            List<string[]> ScheduleList = new List<string[]>();
            string[] item = new string[2];
            for (int i = 0; i < teams.Length; i++)
            {
                team1 = teams[1];
                game.Add(team1);
                for (int j = i + 1; j < teams.Length; j++)
                {
                    team2 = teams[j];
                    game.Add(team2);
                    item = game.ToArray();
                    ScheduleList.Add(item);
                    game.RemoveAt(1);
                }
            }
                return ScheduleList;
        }
        public List<DateTime> TimeSchedule(DateTime StartDate)
        {
            List<DateTime> gameDays = new List<DateTime>();
            gameDays.Add(StartDate);
            for (int i = 1; i < numberOfWeeks; i++)
            {
                gameDays.Add(StartDate.AddDays(i * 7));
            }
                return gameDays;
        }
        public Tuple<string[], DateTime>[] GenerateSchedule(string[] teams, DateTime StartDate)
        {
            Tuple<string[], DateTime>[] schedule = new Tuple<string[], DateTime>[TotalGames(teams)];
            List<DateTime> times = TimeSchedule(StartDate);
            List<string[]> listOfGames = GenerateGames(teams);
            Tuple<string[], DateTime> game;
            int count = 0;
            for (int i = 0; i < 6; i++)
            {

                    for (int j = 0; j < TotalGames(teams) / 6; j++)
                    {
                        game = Tuple.Create(listOfGames[count], times[i]);
                        schedule[count] = game;
                        if (count == TotalGames(teams)/2 -1)
                    {
                        count = 0;
                    }
                    else  
                        count++;
                    }
                    
                
            }

            return schedule;
        }
        public List<Schedule> GetScheduleList()
        {
            return new List<Schedule>
        {
            new Schedule
            {
                Id = 1,
                team1 = "Warriors Team",
                team2 = "Vandals Team",
                Date = DateTime.Today
            },
            new Schedule
            {
                Id = 1,
                team1 = "WSU Team",
                team2 = "WU Team",
                Date = DateTime.Today
            },
             new Schedule
            {
                Id = 1,
                team1 = "FFF Team",
                team2 = "WRE Team",
                Date = DateTime.Today
            },
             new Schedule
            {
                Id = 1,
                team1 = "YRE Team",
                team2 = "REW Team",
                Date = DateTime.Today
            },
             new Schedule
            {
                Id = 1,
                team1 = "SRE Team",
                team2 = "EMS Team",
                Date = DateTime.Today
            },
              new Schedule
            {
                Id = 1,
                team1 = "Warriors Team",
                team2 = "Vandals Team",
                Date = DateTime.Today
            },
               new Schedule
            {
                Id = 1,
                team1 = "WSU Team",
                team2 = "WU Team",
                Date = DateTime.Today
            },
                new Schedule
            {
                Id = 1,
                team1 = "FFF Team",
                team2 = "WRE Team",
                Date = DateTime.Today
            },
                  new Schedule
            {
                Id = 1,
                team1 = "YRE Team",
                team2 = "REW Team",
                Date = DateTime.Today
            },
                new Schedule
            {
                Id = 1,
                team1 = "SRE Team",
                team2 = "EMS Team",
                Date = DateTime.Today
            },
        };
        }

        public ActionResult Index()
        {
            //Tuple<string[], DateTime>[] Schedule = GenerateSchedule(GenTeamList(), DateTime.Today);
            //string[] s = Schedule.ToArray();
            //string[] item = ;

            //var team1 = from x in Schedule
            //            select x.Item1[0];
            //var team2 = from k in Schedule
            //            select k.Item1[1];
            //var Date = from j in Schedule
            //           select j.Item2;
            var schedule = from e in GetScheduleList()
                        orderby e.Date
                        select e;
            return View(schedule);
        }
    }
}



