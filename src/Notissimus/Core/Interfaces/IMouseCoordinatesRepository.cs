using Core.Models;

namespace Core.Interfaces;

public interface IMouseCoordinatesRepository
{
    Task<int> AddAsync(MouseCoordinatesModel model);
}