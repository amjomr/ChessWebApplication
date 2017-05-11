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
            for (int i = 0; i < teams.Length; i++)
            {
                team1 = teams[1];
                game.Add(team1);
                for (int j = i + 1; j < teams.Length; j++)
                {
                    team2 = teams[j];
                    game.Add(team2);
                    string[] s = game.ToArray();
                    ScheduleList.Add(s);
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

    
       
        //public List<Schedule> GetScheduleList()
        //{
        //    List<Schedule> result = new List<Schedule>();



        //    return result;
        //}
        public ActionResult Index()
        {
            Tuple<string[], DateTime>[] Schedule = GenerateSchedule(GenTeamList(), DateTime.Today);
            string[][] items = new string[GenTeamList().Length][];
            for (int i = 0; i < TotalGames(GenTeamList()); i++ )
            {
                Tuple<string[], DateTime> s = Schedule[i];
                items[i] = s.Item1;
                string[] wop = items[i];
                for (int n = 0; n < 2; n++)
                {
                    string woop = wop[n];
                }
                
            }
            var team1 = from x in Schedule
                        select x.Item1[0];
            var team2 = from k in Schedule
                        select k.Item1[1];
            var Date = from j in Schedule
                       select j.Item2;
            return View(team1,team2,Date);
        }
    }
}



