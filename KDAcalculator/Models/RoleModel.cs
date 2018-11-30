using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class RoleModel
    {
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        int RoleID { get; set; }

        public RoleModel(string RoleName, int RoleID)
        {
            this.RoleName = RoleName;
            this.RoleID = RoleID;
        }
    }
}