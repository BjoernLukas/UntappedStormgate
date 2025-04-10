using Microsoft.EntityFrameworkCore;
using UntappedAPI.Models;

namespace UntappedAPI.DataUtility;


public class TemplateDbContext : DbContext
{
    public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
   
}
