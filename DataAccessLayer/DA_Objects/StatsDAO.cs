using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DA_Objects
{
    public class StatsDAO
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public decimal Average { get; set; }
        //public int StatID { get; set; }
        public string FKPlayerName { get; set; }

    }
}
