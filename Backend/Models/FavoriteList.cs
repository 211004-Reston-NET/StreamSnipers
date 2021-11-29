using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class FavoriteList
    {
        public int FavoriteListId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ImdbId { get; set; }

        public string Name { get; set; }
        public bool Netflix { get; set; }
        public bool Hulu { get; set; }
        public bool HboMax { get; set; }
        public bool AmazonVideo { get; set; }
        public bool DisneyPlus { get; set; }
    }
}