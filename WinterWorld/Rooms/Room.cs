using System.Numerics;
public class Room
{    
    static protected Random generator;
    protected Direction entrance;
    protected Dictionary<Direction, bool> openDoors = new Dictionary<Direction, bool>();
    public String[] mapDisplay = new String[]
    {
        "       ",
        "       ",
        "       "
    };
    
    public void openDoor(Direction newOpen)
    {
        openDoors[newOpen] = true;
    }
    public Room()
    {
        openDoors.Add(Direction.North, false);
        openDoors.Add(Direction.East, false);
        openDoors.Add(Direction.South, false);
        openDoors.Add(Direction.West, false);
    }
    public string displayRoom(int row)
    {
        row = Math.Clamp(row,0,2);
        return mapDisplay[row];
    }
    public void EnterNewRoom(Direction enterFrom)
    {
        switch(enterFrom)
        {  
            case Direction.North:
                entrance = Direction.South;
                break;
            case Direction.East:
                entrance = Direction.West;
                break;
            case Direction.South:
                entrance = Direction.North;
                break;
            case Direction.West:
                entrance = Direction.East;
                break;    
        }
        openDoors[entrance] = true;
    }
    public bool DirectionIsOpen(Direction dir)
    {
        return openDoors[dir];
    }
    public bool DirectionIsOpen(Vector2 RoomPos, Direction dir)
    {
        if(dir == Direction.North && RoomPos.X == 0)
        {
            return false;
        }
        if(dir == Direction.West && RoomPos.Y == 0)
        {
            return false;
        }
        if(dir == Direction.South && RoomPos.X == 10)
        {
            return false;
        }
        if(dir == Direction.East && RoomPos.Y == 10)
        {
            return false;
        }
        
        return openDoors[dir];
    }
}