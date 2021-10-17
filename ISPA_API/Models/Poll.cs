using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Poll
    {
		public int poll_id { get; set; }
		public string poll_title { get; set; }
		public string poll_opt1 { get; set; }
		public string poll_opt2 { get; set; }
		public string poll_opt3 { get; set; }
		public string poll_opt4 { get; set; }
		public int poll_opt1count { get; set; }
		public int poll_opt2count { get; set; }
		public int poll_opt3count { get; set; }
		public int poll_opt4count { get; set; }
		public bool poll_active { get; set; }
	}
}
