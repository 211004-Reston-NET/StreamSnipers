using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(40)]
        public string Genre { get; set; }
    }
}