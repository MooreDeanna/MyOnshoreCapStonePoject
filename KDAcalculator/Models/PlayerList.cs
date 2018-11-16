using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class PlayerList
    {
        public PlayerModel SinglePlayer { get; set; }
        public List<PlayerModel> _PlayerList { get; set; }

        public PlayerList()
        {
            SinglePlayer = new PlayerModel();
            _PlayerList = new List<PlayerModel>();
        }
    }
}