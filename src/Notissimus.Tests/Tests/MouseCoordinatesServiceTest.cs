using Application.Services;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

namespace Tests;

public class MouseCoordinatesServiceTest
{
    private readonly DbContextOptionsBuilder<NotissimusDbContext> _options;
    private readonly NotissimusDbContext _database;
    private readonly IMouseCoordinatesRepository _repository;
    private readonly IMouseCoordinatesService _service;

    public MouseCoordinatesServiceTest()
    {
        _options = new DbContextOptionsBuilder<NotissimusDbContext>();
        _options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _database = new NotissimusDbContext(_options.Options);
        _repository = new MouseCoordinatesRepository(_database);
        _service = new MouseCoordinatesService(_repository);
    }

    [Fact]
    public async Task AddModelTest()
    {
        var model = new MouseCoordinatesModel
        {
            Coordinates = new List<Coordinates>
                { new Coordinates { X = 1, Y = 2, T = DateTime.Now } }
        };
        
        var modelId = await _service.AddAsync(model);
        
        Assert.Equal(1, modelId);
    }
}