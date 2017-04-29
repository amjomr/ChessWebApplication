using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace ChessWebApplication.Models
{
    public class Results
    {
        [Key]
        public int WeekNum { get; set; }

        public string Winner { get; set; }
        public string Loser { get; set; }

        public int WID { get; set; } //winner ID
        public int LID { get; set; } //loser ID

        public int WTotalScore { get; set; }
        public int LTotalScore { get; set; }
    }

    public class ResultsDBContext : DbContext
    {
        public DbSet<Results> Result { get; set; }
    }
}