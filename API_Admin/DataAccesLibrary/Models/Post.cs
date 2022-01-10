using System.Collections.Generic;

namespace DataAccesLibrary.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public string CreatorUsername { get; set; }
        public long CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
}