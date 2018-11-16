using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DA_Objects
{
    public class PlayerDAO
    {
        public string PlayerName { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerCity { get; set; }
        public string PlayerState { get; set; }
        public int PlayerAge { get; set; }
        public string PlayerPassword { get; set; }
        public int FKRoleID { get; set; }
        public int PlayerID { get; set; }
        
        
    }
}
