using Animals_Web.Animals;
using Microsoft.EntityFrameworkCore;

namespace Animals_Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public virtual DbSet<Animal> Animals
        {
            get;
            set;

        }




    }











}