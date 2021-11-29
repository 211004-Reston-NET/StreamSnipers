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
    }
}