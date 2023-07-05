using Microsoft.EntityFrameworkCore;
using Registration_DE.Models;

namespace Registration_DE.DBContext
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
        { }

        public DbSet<Models.Register> Registers { get; set; }


    }
}
