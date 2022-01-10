namespace DataAccesLibrary.Models
{
    public class CreatorFans
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }
        public Creator Creator { get; set; }

        public long FanId { get; set; }
        public Fan Fan { get; set; }
    }
}