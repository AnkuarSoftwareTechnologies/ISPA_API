using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class postComent
    {
        public int postcoment_id { get; set; }
        public DateTime postcoment_time { get; set; }
        public string postcoment_coment { get; set; }
        public int postcoment_by { get; set; }
        public int postcoment_post { get; set; }
    }
}
