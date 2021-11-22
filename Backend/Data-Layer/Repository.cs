using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data_Layer
{
    public class Repository : IRepository
    {
        private SSDBContext _context;
        public Repository(SSDBContext p_context)
        {
            _context = p_context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                            .Include("FavoriteList")
                            .Include("PreviousSearch")
                            .Include("Recommendation")
                            .Include("Review")
                            .ToList();
        }

        public User GetUserById(int p_id)
        {
            return _context.Users
                            .Include("FavoriteList")
                            .Include("PreviousSearch")
                            .Include("Recommendation")
                            .Include("Review")
                            .FirstOrDefault(user => user.UserId == p_id);
        }
    }
}
