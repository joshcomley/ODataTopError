using Microsoft.EntityFrameworkCore;
using ODataTopError.Models;

namespace ODataTopError
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}