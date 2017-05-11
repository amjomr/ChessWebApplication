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
        public Tuple<List<String>, DateTime> Id { get; set; }
    }

    public class TeamDBContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
    }
}