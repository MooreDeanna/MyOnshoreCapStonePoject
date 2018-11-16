using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class StatsModel
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public decimal Average { get; set; }
        //public int StatID { get; set; }
        public string FKPlayerName { get; set; }
    }
}