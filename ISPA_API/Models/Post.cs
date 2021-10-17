using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Post
    {
		public int post_id { get; set; }
		public string post_title { get; set; }
		public string post_description { get; set; }
		public DateTime post_date { get; set; }
		public int post_by { get; set; }
		public int post_likecount { get; set; }
		public int post_dislikecount { get; set; }
		public string post_imgpath { get; set; }
		public int post_poll { get; set; }
	}
}
