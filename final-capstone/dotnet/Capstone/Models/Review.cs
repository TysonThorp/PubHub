namespace Capstone.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BeerId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
