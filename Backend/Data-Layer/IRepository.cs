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
        /// Returns a single User from the DB with an ID matching p_id.
        /// </summary>
        /// <param name="p_id">The ID of the user to find</param>
        /// <returns>The User found by ID.</returns>
        User GetUserById(int p_id);
    }
}