using Microsoft.EntityFrameworkCore;
using System;
using UntappedAPI.Models;
using UntappedAPI.Models.Untapped;
using UntappedAPI.Models.Untapped.PlayerStats;

namespace UntappedAPI.DataUtility;


public class UntappedDbContext : DbContext
{
    public UntappedDbContext(DbContextOptions<UntappedDbContext> options) : base(options)
    {
    }

    public DbSet<PlayerSnapshot> PlayerSnapshot { get; set; }

    //public DbSet<CuratedStats> CuratedStats { get; set; }

    //public DbSet<Profile> Profile { get; set; }


}
