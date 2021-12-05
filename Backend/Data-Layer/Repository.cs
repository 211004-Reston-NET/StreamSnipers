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


        public bool UpdateUser(User user)
        {
            var userExist = _context.Users
                                    .Include("FavoriteList")
                                    .Include("PreviousSearch")
                                    .Include("Recommendation")
                                    .Include("Review")
                                    .FirstOrDefault(f => f.UserId == user.UserId);
            if (userExist != null)
            {
                userExist.UserId = user.UserId;
                userExist.Username = user.Username;
                userExist.Email = user.Email;
                userExist.Admin = user.Admin;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User UpdateUserByUsername(string uname, User user)
        {
            var _user = _context.Users.Include("FavoriteList")
                                      .Include("PreviousSearch")
                                      .Include("Recommendation")
                                      .Include("Review")
                                      .FirstOrDefault(f => f.Username == uname);
            if (_user != null)
            {
                _user.UserId = user.UserId;
                _user.Username = user.Username;
                _user.Email = user.Email;
                _user.Admin = user.Admin;
                _context.SaveChanges();
            }
            return _user;
        }
        public User UpdateUserByEmail(string email, User user)
        {
            var _user = _context.Users.Include("FavoriteList")
                                      .Include("PreviousSearch")
                                      .Include("Recommendation")
                                      .Include("Review")
                                      .FirstOrDefault(f => f.Email == email);
            if (_user != null)
            {
                _user.UserId = user.UserId;
                _user.Username = user.Username;
                _user.Email = user.Email;
                _user.Admin = user.Admin;
                _context.SaveChanges();
            }
            return _user;
        }


        public User UpdateUserById(int userId, User user)
        {
            var _user = _context.Users.Include("FavoriteList")
                                      .Include("PreviousSearch")
                                      .Include("Recommendation")
                                      .Include("Review")
                                      .FirstOrDefault(f => f.UserId == userId);
            if (_user != null)
            {
                _user.UserId = user.UserId;
                _user.Username = user.Username;
                _user.Email = user.Email;
                _user.Admin = user.Admin;
                _context.SaveChanges();
            }
            return _user;
        }

        public bool UpdateFavoriteList(FavoriteList fList)
        {
            var result = _context.FavoriteLists.Where(f => f.FavoriteListId == fList.FavoriteListId).FirstOrDefault();
            if (result?.FavoriteListId > 0)
            {
                result.FavoriteListId = fList.FavoriteListId;
                result.Name = fList.Name;
                result.ImdbId = fList.ImdbId;
                result.UserId = fList.UserId;
                result.Hulu = fList.Hulu;
                result.HboMax = fList.HboMax;
                result.Netflix = fList.Netflix;
                result.DisneyPlus = fList.DisneyPlus;
                result.AmazonVideo = fList.AmazonVideo;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public FavoriteList UpdateFavoriteListById(int FavoriteListId, FavoriteList fList)
        {
            var _fList = _context.FavoriteLists.FirstOrDefault(f => f.FavoriteListId == fList.FavoriteListId);
            if (_fList != null)
            {
                _fList.FavoriteListId = fList.FavoriteListId;
                _fList.Name = fList.Name;
                _fList.ImdbId = fList.ImdbId;
                _fList.UserId = fList.UserId;
                _fList.Hulu = fList.Hulu;
                _fList.HboMax = fList.HboMax;
                _fList.Netflix = fList.Netflix;
                _fList.DisneyPlus = fList.DisneyPlus;
                _fList.AmazonVideo = fList.AmazonVideo;
                _context.SaveChanges();
            }
            return _fList;
        }


        public bool UpdatePreviousSearch(PreviousSearch prevSearch)
        {
            var result = _context.PreviousSearches.Where(f => f.PreviousSearchId == prevSearch.PreviousSearchId).FirstOrDefault();
            if (result?.PreviousSearchId > 0)
            {
                result.PreviousSearchId = prevSearch.PreviousSearchId;
                result.UserId = prevSearch.UserId;
                result.Search = prevSearch.Search;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PreviousSearch UpdatePreviousSearchById(int PreviousSearchId, PreviousSearch prevSearch)
        {
            var _prevSearch = _context.PreviousSearches.FirstOrDefault(f => f.PreviousSearchId == prevSearch.PreviousSearchId);
            if (_prevSearch != null)
            {
                _prevSearch.PreviousSearchId = _prevSearch.PreviousSearchId;
                _prevSearch.UserId = _prevSearch.UserId;
                _prevSearch.Search = _prevSearch.Search;
                _context.SaveChanges();
            }
            return _prevSearch;
        }

        public bool UpdateRecommendation(Recommendation rec)
        {
            var result = _context.Recommendations.Where(f => f.RecommendationId == rec.RecommendationId).FirstOrDefault();
            if (result?.RecommendationId > 0)
            {
                result.RecommendationId = rec.RecommendationId;
                result.UserId = rec.UserId;
                result.Genre = rec.Genre;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Recommendation UpdateRecommendationById(int RecommendationId, Recommendation rec)
        {
            var recommendation = _context.Recommendations.FirstOrDefault(f => f.RecommendationId == rec.RecommendationId);
            if (recommendation != null)
            {
                recommendation.RecommendationId = rec.RecommendationId;
                recommendation.UserId = rec.UserId;
                recommendation.Genre = rec.Genre;
                _context.SaveChanges();
            }
            return recommendation;
        }

        public bool UpdateReview(Review rev)
        {
            var result = _context.Reviews.Where(f => f.ReviewId == rev.ReviewId).FirstOrDefault();
            if (result?.ReviewId > 0)
            {
                result.ReviewId = rev.ReviewId;
                result.UserId = rev.UserId;
                result.Text = rev.Text;
                result.Rating = rev.Rating;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Review UpdateReviewById(int ReviewId, Review rev)
        {
            var review = _context.Reviews.FirstOrDefault(f => f.ReviewId == rev.ReviewId);
            if (review != null)
            {
                review.ReviewId = rev.ReviewId;
                review.UserId = rev.UserId;
                review.Text = rev.Text;
                review.Rating = rev.Rating;
                _context.SaveChanges();
            }
            return review;
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

        public User GetUserByEmail(string p_email)
        {
            var result = _context.Users.FirstOrDefault(user => user.Email == p_email);
            return result;
        }

        public List<Review> GetAllReviewByImdbId(string p_imdbId)
        {
            return _context.Reviews.Where(rev => rev.ImdbId == p_imdbId).ToList();
        }
    }
}
