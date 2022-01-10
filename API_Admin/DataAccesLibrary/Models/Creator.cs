using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.Models
{
    public class Creator : User
    {
        public string Bio { get; set; }
        public string Website { get; set; }
        public List<CreatorFans> Followers { get; set; } = new List<CreatorFans>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Fan> BannedFans { get; set; } = new List<Fan>();
    }
}
