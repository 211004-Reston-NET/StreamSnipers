﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models
{
    public class User
    {
        private string _email;
        [Key]
        public int UserId { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email 
        { 
            get { return _email;}
            set { if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new Exception("Not a valid email address");
                }
                _email = value; }
        }

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
