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

        public List<FavoriteList> GetAllFavoriteListByUserId(int p_userId)
        {
            return _context.FavoriteLists
                                .Where(favorite => favorite.UserId == p_userId)
                                .AsNoTracking()
                                .ToList();
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

        public FavoriteList GetFavoriteListById(int p_FavoriteListId)
        {
            return _context.FavoriteLists.FirstOrDefault(favorite => favorite.FavoriteListId == p_FavoriteListId);
        }

        public User GetUserById(int p_userId)
        {
            return _context.Users
                            .Include("FavoriteList")
                            .Include("PreviousSearch")
                            .Include("Recommendation")
                            .Include("Review")
                            .FirstOrDefault(user => user.UserId == p_userId);
        }
    }
}
