public class Room
{    
    static protected Random generator;
    protected Direction entrance;
    protected Dictionary<Direction, bool> openDoors = new Dictionary<Direction, bool>();
    
    public Room()
    {
        openDoors.Add(Direction.North, false);
        openDoors.Add(Direction.East, false);
        openDoors.Add(Direction.South, false);
        openDoors.Add(Direction.West, false);
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
}