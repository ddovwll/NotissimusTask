using Core.Models;
using WebApp.Models.Request;

namespace WebApp.Services.Mappers;

public static class MouseCoordinatesMapper
{
    public static MouseCoordinatesModel Map(MouseCoordinatesRequestModel model)
    {
        return new MouseCoordinatesModel()
        {
            Coordinates = model.Coordinates
        };
    }
}