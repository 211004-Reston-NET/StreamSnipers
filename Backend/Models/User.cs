using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(40)]
        [Required]
        public string Username { get; set; }

        public bool Admin { get; set; }
        public List<Review> Review { get; set; }
        public List<PreviousSearch> PreviousSearch { get; set; }
        public List<Recommendation> Recommendation { get; set; }
        public List<FavoriteList> FavoriteList { get; set; }
    }
}
