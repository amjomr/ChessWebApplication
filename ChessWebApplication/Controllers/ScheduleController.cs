using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChessWebApplication.Controllers
{
    public class ScheduleController : Controller
    {
        private const int BYE = -1;

        //private void RotateArray(int[] teams)
        //{

        //    int[] tmp = teams[teams.Length - 1];
        //    Array.Copy(teams, 0, teams, 1, teams.Length - 1);
        //    teams = tmp;
        //}
        private int [,] GenerateScheduleOdd(int num_teams)
        {
            int n2 = (int)((num_teams - 1) / 2);
            int[,] results = new int[num_teams, num_teams];

            int[] teams = new int[num_teams];
            for (int i = 0; i < num_teams; i++) ;

            for (int round = 0; round < n2; round++)
            {
                for (int i = 0; i <n2; i++)
                {
                    int team1 = teams[n2 - i];
                    int team2 = teams[n2 + i + 1];
                    results[team1, round] = team2;
                    results[team2, round] = team1;
                }

                results[teams[0], round] = BYE;

                //RotateArray(teams);
            }
            return results;
        }
        private int[,] GenerateScheduleEven(int num_teams)
        {
            int[,] results = GenerateScheduleOdd(num_teams - 1);

            int[,] results2 = new int[num_teams, num_teams - 1];
            for (int round = 0; round < num_teams - 1; round++)
            {
                if (results[num_teams,round] == BYE)
                {
                    results2[num_teams, round] = num_teams - 1;
                    results2[num_teams - 1, round] = num_teams;
                }
                else
                {
                    results2[num_teams, round] = results[num_teams, round];
                }
            }

            // project
            return results2;
        }
        private int[,] GenerateSchedule(int num_teams)
        {
            if (num_teams % 2 == 0)
                return GenerateScheduleEven(num_teams);
            else
                return GenerateScheduleOdd(num_teams);
        }
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }
    }
}