using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Chat
    {
		public int chat_id { get; set; }
		public int chat_host { get; set; }
		public int chat_audience { get; set; }
		public int chat_from { get; set; }
		public string chat_message { get; set; }
		public DateTime chat_datetime { get; set; }
	}
}
