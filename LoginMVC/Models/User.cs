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
        
        [StringLength(60, MinimumLength = 4)]
        [Required]
        [Display(Name = "User")]
        public string Name { get; set; }

        [Required]
        private string _pass;
        
        [StringLength(60, MinimumLength = 4)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] // Not need the StringLength if use the next regular expression ;)
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")] // 8 and 15 characters. contains at least one number, one uppercase letter, one lowercase letter one special character.
        [Display(Name = "Password")]
        public string Pass

        {
            get { return Tools.PasswordHelper.Base64Decode(this._pass, this.Name); }

            set { this._pass = Tools.PasswordHelper.Base64Encode(value, this.Name); }
        }
        
        public string Role { get; set; }
    }
}
