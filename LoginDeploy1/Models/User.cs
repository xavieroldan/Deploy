using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDeploy1.Models
{
    public class User
    {

        public int ID { get; set; }
        public string name { get; set; }

        private string _pass;
        public string pass

        {            
            get { return Tools.PasswordHelper.Base64Decode(this._pass, this.name); }

            set { this._pass = Tools.PasswordHelper.Base64Encode(value, this.name); }
        }

    }
}
