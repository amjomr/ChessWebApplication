using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    }
}