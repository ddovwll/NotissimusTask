using System.Text.Json;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.ModelOptions;

public static class MouseCoordinatesOptions
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        var jsonOptions = new JsonSerializerOptions();

        modelBuilder.Entity<MouseCoordinatesModel>(entity =>
        {
            entity.Property(e => e.Coordinates)
                .HasColumnType("jsonb")
                .HasConversion(
                    c => JsonSerializer.Serialize(c, jsonOptions),
                    c => JsonSerializer.Deserialize<List<Coordinates>>(c, jsonOptions)
                         ?? new List<Coordinates>());
        });
    }
}