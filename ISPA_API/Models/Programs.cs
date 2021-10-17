using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Programs
    {
		public int program_id { get; set; }
		public string program_title { get; set; }
		public string program_description { get; set; }
		public string program_livetime { get; set; }
		public string program_catagory { get; set; }
		public string program_smsnumber { get; set; }
		public string program_callnumber { get; set; }
		public string program_station { get; set; }
		public string program_picpath { get; set; }
		public int program_followcount { get; set; }
	}
}
