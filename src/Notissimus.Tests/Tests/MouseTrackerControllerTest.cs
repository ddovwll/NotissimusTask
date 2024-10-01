using Application.Services;
using Core.Interfaces;
using Core.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using WebApp.Controllers;
using WebApp.Models.Request;

namespace Tests;

public class MouseTrackerControllerTest
{
    private readonly DbContextOptionsBuilder<NotissimusDbContext> _options;
    private readonly NotissimusDbContext _database;
    private readonly IMouseCoordinatesRepository _repository;
    private readonly IMouseCoordinatesService _service;
    private readonly MouseTrackerController _controller;

    public MouseTrackerControllerTest()
    {
        _options = new DbContextOptionsBuilder<NotissimusDbContext>();
        _options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _database = new NotissimusDbContext(_options.Options);
        _repository = new MouseCoordinatesRepository(_database);
        _service = new MouseCoordinatesService(_repository);
        _controller = new MouseTrackerController(_service);
    }

    [Fact]
    public async Task AddModelTest()
    {
        var model = new MouseCoordinatesRequestModel()
        {
            Coordinates = new List<Coordinates>
                { new Coordinates { X = 1, Y = 2, T = DateTime.Now } }
        };

        var request = await _controller.TrackAsync(model);

        request.Should().BeOfType<OkResult>();
    }
}