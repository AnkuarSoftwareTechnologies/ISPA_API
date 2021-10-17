using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Podcast
    {
		public int podcast_id { get; set; }
		public string podcast_title { get; set; }
		public string podcast_description { get; set; }
		public string podcast_filepath { get; set; }
		public DateTime podcast_date { get; set; }
		public int podcast_uploadby { get; set; }
		public int podcast_likecount { get; set; }
		public int podcast_dislikecount { get; set; }
		public int podcast_listencount { get; set; }
		public int podcast_program { get; set; }
	}
}
