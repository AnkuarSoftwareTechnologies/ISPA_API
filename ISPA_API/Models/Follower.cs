using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class Follower
    {
        public int follower_audience { get; set; }
        public int follower_program { get; set; }
        public DateTime follower_datetime { get; set; }
    }
}
