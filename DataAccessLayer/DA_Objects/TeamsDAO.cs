using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DA_Objects
{
    public class TeamsDAO
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }   
        public int TeamID { get; set; }
        public string FKPlayerName { get; set; }
        public int PositionsAvaliable { get; set; }
        public int PositionsTaken { get; set; }      
    }
}
