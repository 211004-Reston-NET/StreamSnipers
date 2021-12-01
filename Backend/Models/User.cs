using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models
{
    public class User
    {
        private string _email;
        private string _username;

        [Key]
        public int UserId { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email 
        { 
            get { return _email;}
            set 
            { 
                if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new Exception("Not a valid email address");
                }
                _email = value; 
            }
        }

        [MaxLength(40)]
        [Required]
        public string Username 
        { 
            get { return _username; }
            set
            {
                if (!Regex.IsMatch(value, @"^((?!\s*$).+){4,}$"))
                {
                    throw new Exception("Not a valiud username.");
                }
                _username = value;
            }
        }

        public bool Admin { get; set; }
        public List<Review> Review { get; set; }
        public List<PreviousSearch> PreviousSearch { get; set; }
        public List<Recommendation> Recommendation { get; set; }
        public List<FavoriteList> FavoriteList { get; set; }
    }
}
