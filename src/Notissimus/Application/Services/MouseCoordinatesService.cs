using Core.Interfaces;
using Core.Models;

namespace Application.Services;

public class MouseCoordinatesService : IMouseCoordinatesService
{
    private readonly IMouseCoordinatesRepository _mouseCoordinatesRepository;

    public MouseCoordinatesService(IMouseCoordinatesRepository mouseCoordinatesRepository)
    {
        _mouseCoordinatesRepository = mouseCoordinatesRepository;
    }

    public async Task<int> AddAsync(MouseCoordinatesModel model)
    {
        var modelId = await _mouseCoordinatesRepository.AddAsync(model);
        
        return modelId;
    }
}