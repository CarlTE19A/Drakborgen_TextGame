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
    /*
    public bool DirectionIsOpen(Vector2 RoomPos, Direction dir)
    {
        if(dir == Direction.North && RoomPos.Y == 0)
        {
            return false;
        }
        if(dir == Direction.West && RoomPos.X == 0)
        {
            return false;
        }
        if(dir == Direction.South && RoomPos.Y == 10)
        {
            return false;
        }
        if(dir == Direction.East && RoomPos.X == 10)
        {
            return false;
        }
        
        return openDoors[dir];
    }
    */

    public void recalculateRoom()
    {
        if(GetType().Name == "Corridor")
        {          
            if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.West) && DirectionIsOpen(Direction.South) && DirectionIsOpen(Direction.East))  //All
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "──┘ └──",
                    "──┐ ┌──"};
            }
            else if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.West) && DirectionIsOpen(Direction.South) && !DirectionIsOpen(Direction.East))                                //Missing East
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "──┘ │  ",
                    "──┐ │  "};
            }
            else if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.South) && !DirectionIsOpen(Direction.East))                                                                    //Missing South and East
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "──┘ │  ",
                    "────┘  "};
            }
            else if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.West) && DirectionIsOpen(Direction.East) && !DirectionIsOpen(Direction.South))                                //Missing South
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "──┘ └──",
                    "───────"};
            }
            else if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.East) && !DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.South))                                                                    //Missing South and West
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "  │ └──",
                    "  └────"};
            }
            else if(DirectionIsOpen(Direction.North) && DirectionIsOpen(Direction.East) && DirectionIsOpen(Direction.South) && !DirectionIsOpen(Direction.West))                                //Missing West
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "  │ └──",
                    "  │ ┌──"};
            }
            else if(DirectionIsOpen(Direction.South) && DirectionIsOpen(Direction.East) && !DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.North))                                                                    //Missing West and North
            {
                mapDisplay = new String[]{
                    "       ",
                    "  ┌────",
                    "  │ ┌──"};
            }
            else if(DirectionIsOpen(Direction.East) && DirectionIsOpen(Direction.West) && DirectionIsOpen(Direction.South) && !DirectionIsOpen(Direction.North))                                //Missing North
            {
                mapDisplay = new String[]{
                    "       ",
                    "───────",
                    "──┐ ┌──"};
            }
            else if(DirectionIsOpen(Direction.South) && DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.East) && !DirectionIsOpen(Direction.North))                                                                    //Missing North and East
            {
                mapDisplay = new String[]{
                    "       ",
                    "────┐  ",
                    "──┐ │  "};
            }
            else if(DirectionIsOpen(Direction.South) && DirectionIsOpen(Direction.North) && !DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.East))                                                                    //Missing West and East
            {
                mapDisplay = new String[]{
                    "  │ │  ",
                    "  │ │  ",
                    "  │ │  "};
            }
            else if(DirectionIsOpen(Direction.West) && DirectionIsOpen(Direction.East) && !DirectionIsOpen(Direction.North) && !DirectionIsOpen(Direction.South))                                                                    //Missing North and South
            {
                mapDisplay = new String[]{
                    "       ",
                    "───────",
                    "───────"};
            } 
            else if(!DirectionIsOpen(Direction.North) && !DirectionIsOpen(Direction.West) && !DirectionIsOpen(Direction.South) && !DirectionIsOpen(Direction.East))
            {
                mapDisplay = new String[]{
                    "_EMPTY_",
                    "_EMPTY_",
                    "_EMPTY_"};
            }
            else
            {
                openDoor(Direction.North);
                openDoor(Direction.East);
                recalculateRoom();
                // mapDisplay = new String[]{
                //     "_OTHER_",
                //     "_OTHER_",
                //     "_OTHER_"};
                Console.WriteLine($"{DirectionIsOpen(Direction.North)}, {DirectionIsOpen(Direction.West)} + {DirectionIsOpen(Direction.South)} + {DirectionIsOpen(Direction.East)}");
            }
        } 
    }
}