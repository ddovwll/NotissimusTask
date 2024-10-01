using Core.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.ModelOptions;

namespace Persistence;

public class NotissimusDbContext : DbContext
{
    public NotissimusDbContext(DbContextOptions<NotissimusDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MouseCoordinatesOptions.Configure(modelBuilder);
    }

    public DbSet<MouseCoordinatesModel> MouseCoordinates { get; set; }
}