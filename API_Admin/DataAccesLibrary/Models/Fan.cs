using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.Models
{
    public class Fan : User
    {
        public List<CreatorFans> CreatorFans { get; set; } = new List<CreatorFans>();
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public List<LikedPosts> LikedPosts { get; set; } = new List<LikedPosts>();
        public List<SavedPosts> SavedPosts { get; set; } = new List<SavedPosts>();
    }
}
