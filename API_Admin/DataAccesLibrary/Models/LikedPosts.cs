namespace DataAccesLibrary.Models
{
    public class LikedPosts
    {
        public long Id { get; set; }
        public long FanId { get; set; }
        public Fan Fan { get; set; }
        
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}