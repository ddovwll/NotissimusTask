namespace Core.Models;

public class MouseCoordinatesModel
{
    public int Id { get; set; }
    public List<Coordinates> Coordinates { get; set; }
}

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public DateTime T { get; set; }
}