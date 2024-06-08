using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models.Entity;

namespace WebApplicationMVC.Data
{
    public class ApplicationsDBcontext:DbContext
    {
        public ApplicationsDBcontext(DbContextOptions<ApplicationsDBcontext> options): base (options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
