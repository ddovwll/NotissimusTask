using System.Text.Json;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Request;
using WebApp.Services.Mappers;

namespace WebApp.Controllers;

public class MouseTrackerController : Controller
{
    private readonly IMouseCoordinatesService _mouseCoordinatesService;
    
    public MouseTrackerController(IMouseCoordinatesService mouseCoordinatesService)
    {
        _mouseCoordinatesService = mouseCoordinatesService;
    }

    [HttpGet("/")]
    public IActionResult Track()
    {
        return View();
    }

    [HttpPost("/")]
    public async Task<IActionResult> TrackAsync([FromBody] MouseCoordinatesRequestModel model)
    {
        if (model is null || model.Coordinates is null || model.Coordinates.Count == 0)
        {
            return BadRequest();
        }
        try
        {
            await _mouseCoordinatesService.AddAsync(MouseCoordinatesMapper.Map(model));
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        return Ok();
    }
}