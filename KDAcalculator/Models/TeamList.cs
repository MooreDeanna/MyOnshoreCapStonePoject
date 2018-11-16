using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class TeamList
    {
        public TeamsModel SingleTeam { get; set; }
        public List<TeamsModel> _TeamsList { get; set; }

        public TeamList()
        {
            SingleTeam = new TeamsModel();
            _TeamsList = new List<TeamsModel>();
        }
    }
}