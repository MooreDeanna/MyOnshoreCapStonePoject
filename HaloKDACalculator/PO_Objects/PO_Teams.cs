using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloKDACalculator.PO_Objects
{
    public class PO_Teams
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public int TeamID { get; set; } 
        public string FKPlayerName { get; set; }        
        public int PositionsAvaliable { get; set; }
        public int PositionsTaken { get; set; }
                   
    }
}
