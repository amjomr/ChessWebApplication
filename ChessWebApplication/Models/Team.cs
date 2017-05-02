using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChessWebApplication.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Totalscore { get; set; }

        public List<Schedule> Schedules { get; set; }
    }

    public class TeamDBContext : DbContext
    {
        public DbSet<Team> Team { get; set; }

        public System.Data.Entity.DbSet<ChessWebApplication.Models.Schedule> Schedules { get; set; }
    }
}