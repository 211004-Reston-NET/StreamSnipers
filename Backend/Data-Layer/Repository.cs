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

        public User AddUser(User p_userToAdd)
        {
            _context.Users.Add(p_userToAdd);
            _context.SaveChanges();
            return p_userToAdd;
        }

        public FavoriteList AddFavoriteList(FavoriteList p_FavoriteListToAdd)
        {
            var result = _context.Users
                            .Include("FavoriteList")
                            .FirstOrDefault(user => user.UserId == p_FavoriteListToAdd.UserId);
            result.FavoriteList.Add(p_FavoriteListToAdd);
            _context.SaveChanges();
            return p_FavoriteListToAdd;
        }

        public PreviousSearch AddPreviousSearch(PreviousSearch p_previousSearchToAdd)
        {
            var result = _context.Users
                            .Include("PreviousSearch")
                            .FirstOrDefault(user => user.UserId == p_previousSearchToAdd.UserId);
            result.PreviousSearch.Add(p_previousSearchToAdd);
            _context.SaveChanges();
            return p_previousSearchToAdd;
        }

        public Recommendation AddRecommendation(Recommendation p_recommendationToAdd)
        {
            var result = _context.Users
                            .Include("Recommendation")
                            .FirstOrDefault(user => user.UserId == p_recommendationToAdd.UserId);
            result.Recommendation.Add(p_recommendationToAdd);
            _context.SaveChanges();
            return p_recommendationToAdd;
        }

        public Review AddReview(Review p_reviewToAdd)
        {
            var result = _context.Users
                            .Include("Review")
                            .FirstOrDefault(user => user.UserId == p_reviewToAdd.UserId);
            result.Review.Add(p_reviewToAdd);
            _context.SaveChanges();
            return p_reviewToAdd;
        }

        public User DeleteUserById(int p_userIdToDelete)
        {
            var result = _context.Users.FirstOrDefault(user => user.UserId == p_userIdToDelete);
            _context.Users.Remove(result);
            _context.SaveChanges();
            return result; 
        }

        public FavoriteList DeleteFavoriteListById(int p_favoriteListIdToRemove)
        {
            var result = _context.FavoriteLists.FirstOrDefault(fav => fav.FavoriteListId == p_favoriteListIdToRemove);
            _context.FavoriteLists.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public PreviousSearch DeletePreviousSearchById(int p_previousSearchId)
        {
            var result = _context.PreviousSearches.FirstOrDefault(srch => srch.PreviousSearchId == p_previousSearchId);
            _context.PreviousSearches.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public Recommendation DeleteRecommendationById(int p_recommendationId)
        {
            var result = _context.Recommendations.FirstOrDefault(srch => srch.RecommendationId == p_recommendationId);
            _context.Recommendations.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public Review DeleteReviewById(int p_reviewId)
        {
            var result = _context.Reviews.FirstOrDefault(srch => srch.ReviewId == p_reviewId);
            _context.Reviews.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public User LoginUser(string p_email)
        {
            return _context.Users
                            .Include("FavoriteList")
                            .Include("PreviousSearch")
                            .Include("Recommendation")
                            .Include("Review")
                            .FirstOrDefault(user => user.Email == p_email);
        }
    }
}
