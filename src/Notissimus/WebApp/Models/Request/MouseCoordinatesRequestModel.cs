using Core.Models;

namespace WebApp.Models.Request;

public class MouseCoordinatesRequestModel
{
    public List<Coordinates> Coordinates { get; set; }
}