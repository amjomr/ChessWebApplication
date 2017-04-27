using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChessWebApplication.Models
{
    public class Schedule
    {
      

        [Key]
        public int Id { get; set; }

        public string Team1Id { get; set; }

        public string Team2Id { get; set; }

        public DateTime Date { get; set; }

        public List<Team> Teams { get; set; }

        public class TeamBContext : DbContext
        {
            public DbSet<Schedule> Schedules { get; set; }
        }

    }
}