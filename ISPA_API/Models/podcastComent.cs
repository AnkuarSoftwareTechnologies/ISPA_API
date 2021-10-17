using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class podcastComent
    {
        public int podcastcoment_id { get; set; }
        public DateTime podcastcoment_time { get; set; }
        public string podcastcoment_coment { get; set; }
        public int podcastcoment_by { get; set; }
        public int podcastcoment_podcast { get; set; }
    }
}
