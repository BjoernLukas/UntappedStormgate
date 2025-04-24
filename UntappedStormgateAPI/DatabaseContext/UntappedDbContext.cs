using Microsoft.EntityFrameworkCore;
using UntappedAPI.Models;


namespace UntappedAPI.DatabaseContext;


public class UntappedDbContext : DbContext
{
    public UntappedDbContext(DbContextOptions<UntappedDbContext> options) : base(options)
    {
    }

    public DbSet<PlayerSnapshot> PlayerSnapshot { get; set; }

    //public DbSet<CuratedStats> CuratedStats { get; set; }

    //public DbSet<Profile> Profile { get; set; }


}
