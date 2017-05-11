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

        public string team1 { get; set; }

        public string team2 { get; set; }

        public DateTime Date { get; set; }
    }

    public class TeamDBContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
    }
}