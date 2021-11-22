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
        /// Returns a List of FavoriteLists from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the user the FavoriteList references.</param>
        /// <returns>List of FavoriteLists found by UserId.</returns>
        List<FavoriteList> GetFavoriteListByUserId(int p_userId);

        /// <summary>
        /// Returns a single FavoriteList from the DB with FavoriteListId matching p_FavoriteListId.
        /// </summary>
        /// <param name="p_FavoriteListId">The ID for the FavoriteList to find.</param>
        /// <returns>The FavoriteList found by FavoriteListId.</returns>
        FavoriteList GetFavoriteListById(int p_favoriteListId);

        /// <summary>
        /// Returns a List of PreviousSearch from the DB with a UserId matching p_userId.
        /// </summary>
        /// <param name="p_userId">The ID for the user the PreviousSearch references.</param>
        /// <returns>List of PreviousSearch found by UserId.</returns>
        List<PreviousSearch> GetPreviousSearchByUserId(int p_userId);

        /// <summary>
        /// Returns a single PreviousSearch from the DB with PreviousSearchId matching p_previousSearchId.
        /// </summary>
        /// <param name="p_previousSearchId">The ID for the PreviousSearch to find.</param>
        /// <returns>The PreviousSearch found by PreviousSearchId.</returns>
        PreviousSearch GetPreviousSearchById(int p_previousSearchId);
    }
}