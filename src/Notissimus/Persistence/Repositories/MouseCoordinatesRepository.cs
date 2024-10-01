using Core.Interfaces;
using Core.Models;

namespace Persistence.Repositories;

public class MouseCoordinatesRepository : IMouseCoordinatesRepository
{
    private readonly NotissimusDbContext _dbContext;

    public MouseCoordinatesRepository(NotissimusDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(MouseCoordinatesModel model)
    {
        await _dbContext.MouseCoordinates.AddAsync(model);
        await _dbContext.SaveChangesAsync();

        return model.Id;
    }
}