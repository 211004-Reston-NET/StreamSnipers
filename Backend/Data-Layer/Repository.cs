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

        public List<FavoriteList> GetFavoriteListByUserId(int p_userId)
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

        public FavoriteList GetFavoriteListById(int p_favoriteListId)
        {
            return _context.FavoriteLists
                                .AsNoTracking()
                                .FirstOrDefault(favorite => favorite.FavoriteListId == p_favoriteListId);
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

        public List<PreviousSearch> GetPreviousSearchByUserId(int p_userId)
        {
            return _context.PreviousSearches
                                .Where(search => search.UserId == p_userId)
                                .AsNoTracking()
                                .ToList();
        }

        public PreviousSearch GetPreviousSearchById(int p_previousSearchId)
        {
            return _context.PreviousSearches
                                .AsNoTracking()
                                .FirstOrDefault(search => search.PreviousSearchId == p_previousSearchId);
        }

        public List<Recommendation> GetRecommendationByUserId(int p_userId)
        {
            return _context.Recommendations
                                .Where(recomm => recomm.UserId == p_userId)
                                .AsNoTracking()
                                .ToList();
        }

        public Recommendation GetRecommendationById(int p_recommendationId)
        {
            return _context.Recommendations
                                .AsNoTracking()
                                .FirstOrDefault(recomm => recomm.RecommendationId == p_recommendationId);
        }

        public List<Review> GetReviewByUserId(int p_userId)
        {            
            return _context.Reviews
                            .Where(rev => rev.UserId == p_userId)
                            .AsNoTracking()
                            .ToList();
        }

        public Review GetReviewById(int p_reviewId)
        {
            return _context.Reviews
                            .AsNoTracking()
                            .FirstOrDefault(rev => rev.ReviewId == p_reviewId);
        }

        public List<FavoriteList> GetAllFavoriteList()
        {
            return _context.FavoriteLists.ToList();
        }
    }
}
