using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WedFim.Areas.Admin.Models
{

        public class LoginModel
        {
            [Required(ErrorMessage = "Mời bạn nhập vào Username")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Mời bạn nhập vào Password")]
            public string Password { get; set; }

            public bool RememberME { get; set; }
        }
    
}