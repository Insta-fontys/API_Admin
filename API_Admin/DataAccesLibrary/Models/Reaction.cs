namespace DataAccesLibrary.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public long FanId { get; set; }
        public Fan Fan { get; set; }

        public long PostId { get; set; }
        public Post Post { get; set; }
        
        public string Message { get; set; }
    }
}