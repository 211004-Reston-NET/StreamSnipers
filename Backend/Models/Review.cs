using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string ImdbId { get; set; }
        [Required]
        public string Username { get; set; }
    }
}