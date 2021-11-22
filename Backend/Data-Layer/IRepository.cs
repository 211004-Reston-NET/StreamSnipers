using System.Collections.Generic;
using Models;

namespace Data_Layer
{
    public interface IRepository
    {
        /// <summary>
        /// This method will search the database and return a list of all users stored.
        /// </summary>
        /// <returns>Returns a list of Users.</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Returns a single User from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_id">The ID of the user to find.</param>
        /// <returns>The User found by UserId.</returns>
        User GetUserById(int p_userId);


        /// <summary>
        /// Adds a User to the DB.
        /// </summary>
        /// <param name="p_userToAdd">The User that will be added to the DB</param>
        /// <returns>The User that got added.</returns>
        User AddUser(User p_userToAdd);

        /// <summary>
        /// Will return a list of all FavoriteLists
        /// </summary>
        /// <returns>The List of FavoriteLists</returns>
        List<FavoriteList> GetAllFavoriteList();

        /// <summary>
        /// Returns a List of FavoriteLists from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the User the FavoriteList references.</param>
        /// <returns>List of FavoriteLists found by UserId.</returns>
        List<FavoriteList> GetFavoriteListByUserId(int p_userId);

        /// <summary>
        /// Returns a single FavoriteList from the DB with FavoriteListId matching p_FavoriteListId.
        /// </summary>
        /// <param name="p_FavoriteListId">The ID for the FavoriteList to find.</param>
        /// <returns>The FavoriteList found by FavoriteListId.</returns>
        FavoriteList GetFavoriteListById(int p_favoriteListId);

        /// <summary>
        /// Will Search for a User from p_FavoriteListToAdd.UserId and add p_FavoriteListToAdd to the list of FavoriteList.
        /// </summary>
        /// <param name="p_FavoriteListToAdd">The Favorite List to add, also contains the UserId to look for.</param>
        /// <returns>The FavoriteList that got added.</returns>
        FavoriteList AddFavoriteList(FavoriteList p_FavoriteListToAdd);

        /// <summary>
        /// Returns a List of PreviousSearch from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the User the PreviousSearch references.</param>
        /// <returns>List of PreviousSearch found by UserId.</returns>
        List<PreviousSearch> GetPreviousSearchByUserId(int p_userId);

        /// <summary>
        /// Returns a single PreviousSearch from the DB with PreviousSearchId matching p_previousSearchId.
        /// </summary>
        /// <param name="p_previousSearchId">The ID for the PreviousSearch to find.</param>
        /// <returns>The PreviousSearch found by PreviousSearchId.</returns>
        PreviousSearch GetPreviousSearchById(int p_previousSearchId);

        /// <summary>
        /// Will Search for a User from p_previousSearchToAdd.UserId and add p_previousSearchToAdd to the list of PreviousSearches.
        /// </summary>
        /// <param name="p_previousSearchToAdd">The PreviousSearch to add, also contains the UserId to look for.</param>
        /// <returns>The PreviousSearch that got added.</returns>
        PreviousSearch AddPreviousSearch(PreviousSearch p_previousSearchToAdd);

        /// <summary>
        /// Returns a List of Recommendation from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the User the Recommendation references.</param>
        /// <returns>List of Recommendation found by UserId.</returns>
        List<Recommendation> GetRecommendationByUserId(int p_userId);

        /// <summary>
        /// Returns a single Recommendation from the DB with RecommendationId matching p_recommendationId.
        /// </summary>
        /// <param name="p_recommendationId">The ID for the Recommendation to find.</param>
        /// <returns>The Recommendation found by RecommendationId.</returns>
        Recommendation GetRecommendationById(int p_recommendationId);

        /// <summary>
        /// Will Search for a User from p_recommendationToAdd.UserId and add p_recommendationToAdd to the list of Recommendations.
        /// </summary>
        /// <param name="p_recommendationToAdd">The Recommendation to add, also contains the UserId to look for.</param>
        /// <returns>The Recommendation that got added.</returns>
        Recommendation AddRecommendation(Recommendation p_recommendationToAdd);

        /// <summary>
        /// Returns a List of Review from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the User the Review references.</param>
        /// <returns>List of Review found by UserId.</returns>
        List<Review> GetReviewByUserId(int p_userId);

        /// <summary>
        /// Returns a single Review from the DB with ReviewId matching p_reviewId.
        /// </summary>
        /// <param name="p_reviewId">The ID for the Review to find.</param>
        /// <returns>The Review found by ReviewId.</returns>
        Review GetReviewById(int p_reviewId);

        /// <summary>
        /// Will Search for a User from p_reviewToAdd.UserId and add p_reviewToAdd to the list of Reviews.
        /// </summary>
        /// <param name="p_reviewToAdd">The Review to add, also contains the UserId to look for.</param>
        /// <returns>The Review that got added.</returns>
        Review AddReview(Review p_reviewToAdd);
    }
}