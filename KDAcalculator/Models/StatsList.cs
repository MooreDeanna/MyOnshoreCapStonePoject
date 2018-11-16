using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class StatsList
    {        
        public StatsModel SingleStat { get; set; }
        public List<StatsModel> _StatsList { get; set; }

        public StatsList()
        {
            SingleStat = new StatsModel();
            _StatsList = new List<StatsModel>();
        }
    }
}
