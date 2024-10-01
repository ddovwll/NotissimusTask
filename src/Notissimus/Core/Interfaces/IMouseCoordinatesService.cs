using Core.Models;

namespace Core.Interfaces;

public interface IMouseCoordinatesService
{
    Task<int> AddAsync(MouseCoordinatesModel model);
}