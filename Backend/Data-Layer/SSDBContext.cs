using Microsoft.EntityFrameworkCore;
using Models;

namespace Data_Layer
{
    public class SSDBContext : DbContext
    {
        public SSDBContext()
        {
        }

        public SSDBContext(DbContextOptions<SSDBContext> options) : base (options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<PreviousSearch> PreviousSearches { get; set; }
        public virtual DbSet<FavoriteList> FavoriteLists { get; set; }
    }
}