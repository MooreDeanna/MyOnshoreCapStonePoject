using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class PlayerModel
    {
        public bool _Delete { get; set; } = false;
        public bool _Update { get; set; } = false;
        //The DisplayName message is what will show up for the corosponding text box below it when run
        [DisplayName("What would you like to be called?")]
        [Required(ErrorMessage = "***This field is required***")]
        public string PlayerName { get; set; }//constructors       

        [DisplayName("What would you like your TopSecret Passcode to be?")]
        [Required(ErrorMessage = "***This field is required***")]
        public string PlayerPassword { get; set; }

        [DisplayName("What is your FIRST name?")]
        public string PlayerFirstName { get; set; }

        [DisplayName("What is your LAST name?")]
        public string PlayerLastName { get; set; }

        [DisplayName("What City are you from?")]
        public string PlayerCity { get; set; }

        [DisplayName("What is the State?")]
        public string PlayerState { get; set; }

        [DisplayName("How Old Are You?")]
        public int PlayerAge { get; set; }

        [DisplayName("What Access Level Do You Have?")]
        public int FKRoleID { get; set; }


    }
}