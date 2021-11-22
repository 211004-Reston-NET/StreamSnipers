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
        List<FavoriteList> GetAllFavoriteListByUserId(int p_userId);

        /// <summary>
        /// Returns a single FavoriteList from the DB with FavoriteListId matching p_FavoriteListId.
        /// </summary>
        /// <param name="p_FavoriteListId">The ID for the FavoriteList to find.</param>
        /// <returns>The FavoriteList found by FavoriteListId.</returns>
        FavoriteList GetFavoriteListById(int p_FavoriteListId);
    }
}