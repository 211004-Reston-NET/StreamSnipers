using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DTO
{
    public class UpdateUserDTO
    {
        private string _email;
        private string _password;
        private string _username;

        [Key]
        public int UserId { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new Exception("Not a valid email address");
                }
                _email = value;
            }
        }

        [Required]
        public string Password
        {
            get { return _password; }
            set
            {
                if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$"))
                {
                    throw new Exception("Not a valid password, password must containt at least 1 Uppercase letter, 1 lowercase letter, 1 Special character and 1 number.");
                }
                _password = value;
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
