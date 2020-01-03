using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "User")]
        public string Name { get; set; }

        private string _pass;

        [Display(Name = "Password")]
        public string Pass

        {
            get { return Tools.PasswordHelper.Base64Decode(this._pass, this.Name); }

            set { this._pass = Tools.PasswordHelper.Base64Encode(value, this.Name); }
        }
    }
}
