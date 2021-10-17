using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Users
    {
        public int users_id { get; set; }
        public string users_name { get; set; }
        public string users_birthdate { get; set; }
        public char users_sex { get; set; }
        public string users_email { get; set; }
        public string users_password { get; set; }
        public string users_phone { get; set; }
        public string users_address { get; set; }
        public string users_picpath { get; set; }
        public string users_role { get; set; }
        public bool users_active { get; set; }



    }
}
