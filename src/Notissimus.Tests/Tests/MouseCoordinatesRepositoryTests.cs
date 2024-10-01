using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

namespace Tests;

public class MouseCoordinatesRepositoryTests
{
    private readonly DbContextOptionsBuilder<NotissimusDbContext> _options;
    private readonly NotissimusDbContext _database;
    private IMouseCoordinatesRepository _repository;

    public MouseCoordinatesRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<NotissimusDbContext>();
        _options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _database = new NotissimusDbContext(_options.Options);
        _repository = new MouseCoordinatesRepository(_database);
    }
    
    [Fact]
    public async Task AddModelTest()
    {
        var model = new MouseCoordinatesModel
        {
            Coordinates = new List<Coordinates>
                { new Coordinates { X = 1, Y = 2, T = DateTime.Now } }
        };

        var modelId = await _repository.AddAsync(model);

        Assert.Equal(1, modelId);
    }
}