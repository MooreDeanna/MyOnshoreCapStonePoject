using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.LL_Objects
{
    public class TeamsLLObject
    {
        //Taking(Getting) information and Setting it to something

        public string TeamName { get; set; } //Constuctors 
        public string TeamDescription { get; set; }
        public int PositionsAvaliable { get; set; }
        public int PositionsTaken { get; set; }       
    }
}

