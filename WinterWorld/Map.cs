using System.Numerics;
class Map
{
    static private Random randomGenerator = new Random();
    public static Vector2 mapSize = new Vector2(10, 10);
    public static void displayMap(Dictionary<Vector2, Room> rooms)
    {
        int lineAmmount = (int)mapSize.Y * 4 + 1;
        String[] lines = new String[lineAmmount];
        lines[0] = "  ──────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬──────  ";
        for (var y = 1; y < lineAmmount - 1; y++)
        {
            if(y % 4 != 0)
            {
                lines[y] += "│";
            }
            for (var x = 0; x < mapSize.X; x++)
            {
                Vector2 pos = new Vector2(x, (y - 1) / 4);
                if(y % 4 == 0)
                {
                    if(x == 0)
                    {
                        lines[y] += "├";
                    }
                        if(rooms[pos].DirectionIsOpen(Direction.South) || rooms[pos + new Vector2(0,1)].DirectionIsOpen(Direction.North))
                        {
                            if(rooms[pos].GetType().Name == "Corridor" && rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")
                            {
                                lines[y] += "  │ │  ";
                            }
                            else if(rooms[pos].GetType().Name == "Corridor")
                            {
                                lines[y] += "──┘ └──";
                            }
                            else if(rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")
                            {
                                lines[y] += "──┐ ┌──";
                            }
                            else
                            {
                                {
                                    lines[y] += "──   ──";
                                }
                            }
                        }
                        else if(rooms[pos].GetType().Name == "Corridor" && rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")
                        {
                            lines[y] += "       ";
                        }
                        else
                        {
                            lines[y] += "───────";
                        }
                        if(x != 9)
                        {
                           lines[y] += "┼"; 
                        }
                        else
                        {
                            lines[y] += "│";
                        }
                }
                else
                {
                    lines[y] += rooms[pos].displayRoom(y % 4 - 1);
                    if(x != 9)
                    {
                        if(rooms[pos].DirectionIsOpen(Direction.East) || rooms[pos + new Vector2(1,0)].DirectionIsOpen(Direction.West))
                        {
                            if(rooms[pos].GetType().Name == "Corridor" && rooms[pos + new Vector2(1,0)].GetType().Name == "Corridor")
                            {
                                if(y % 4 == 1)
                                {
                                    lines[y] += " ";
                                }
                                else if(y % 4 == 2 || y % 4 == 3)
                                {
                                    lines[y] += "─";
                                }
                                else
                                {
                                    lines[y] += "■";
                                }
                            }
                            else if(rooms[pos].GetType().Name == "Corridor")
                            {
                                if(y % 4 == 1)
                                {
                                    lines[y] += "│";
                                }
                                else if(y % 4 == 2)
                                {
                                    lines[y] += "┘";
                                }
                                else if(y % 4 == 3)
                                {
                                    lines[y] += "┐";
                                }
                                else
                                {
                                    lines[y] += "■";
                                }
                            }
                            else if(rooms[pos + new Vector2(1,0)].GetType().Name == "Corridor")
                            {
                                 if(y % 4 == 1)
                                {
                                    lines[y] += "│";
                                }
                                else if(y % 4 == 2)
                                {
                                    lines[y] += "└";
                                }
                                else if(y % 4 == 3)
                                {
                                    lines[y] += "┌";
                                }
                                else
                                {
                                    lines[y] += "■";
                                }
                            }
                            else
                            {
                                if(y % 4 == 1 || y % 4 == 3)
                                {
                                    lines[y] += "│";
                                }
                                else if(y % 4 == 2)
                                {
                                    lines[y] += " ";
                                }
                                else
                                {
                                    lines[y] += "■";
                                }
                            }
                        }
                        else
                        {
                            lines[y] += "│";
                        }
                    }
                    else
                    {
                        lines[y] += "│";
                    }
                }
            }
        }
        lines[lineAmmount - 1] = "  ──────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┴──────  ";

        foreach (var line in lines)
        {
            System.Console.WriteLine(line);   
        }

        //Room[,] rooms = new Room[10,10];
    }
    public static Dictionary<Vector2, Room> createWorld(Vector2 worldInitSize)        //Old better create world during game
{
    Dictionary<Vector2, Room> worldInitGrid = new Dictionary<Vector2, Room>();  //World Dictonary for all rooms
    Room roomForNext = newRoom(true, Direction.North);
    for (var x = 0; x < worldInitSize.X; x++)
    {
        for (var y = 0; y < worldInitSize.Y; y++)
        {
            if(randomGenerator.Next(0,8) == 1)
            {   
                roomForNext = new Corridor();
                switch (randomGenerator.Next(0,5))
                {
                    case 0:
                        roomForNext = newCorridor(Direction.North);
                        break;
                    case 1:
                        roomForNext = newCorridor(Direction.West);
                        break;
                    case 2:
                        roomForNext = newCorridor(Direction.South);
                        break;
                    case 3:
                        roomForNext = newCorridor(Direction.East);
                        break;
                }
            }
            else
            {
                switch (randomGenerator.Next(0,5))
                {
                    case 0:
                        roomForNext = newRoom(false, Direction.North);
                        break;
                    case 1:
                        roomForNext = newRoom(false, Direction.West);
                        break;
                    case 2:
                        roomForNext = newRoom(false, Direction.South);
                        break;
                    case 3:
                        roomForNext = newRoom(false, Direction.East);
                        break;
                }
                //worldInitGrid.Add(new Vector2(x,y), newRoom(false, new Vector2(x,y), Direction.West));
                //roomForNext = newRoom(false, Direction.West);
            }

            worldInitGrid.Add(new Vector2(x,y), roomForNext);
            Console.Write(roomForNext.DirectionIsOpen(new Vector2(x,y), Direction.North));
            
        }
    }
    return worldInitGrid;
}
    public static Room newRoom(bool isEntrance, Direction enteredFrom)
    {
        Room tempRoom = new Room();
        if(isEntrance == true)
        {
            tempRoom.openDoor(Direction.North);
            tempRoom.openDoor(Direction.West);
            tempRoom.openDoor(Direction.South);   
            tempRoom.openDoor(Direction.East);
        }
        else
        {
           tempRoom.openDoor(enteredFrom);
           if(randomGenerator.Next(0,4) == 1)
           {
               tempRoom.openDoor(Direction.North);
           }
           if(randomGenerator.Next(0,4) == 1)
           {
               tempRoom.openDoor(Direction.West);
           }
           if(randomGenerator.Next(0,4) == 1)
           {
               tempRoom.openDoor(Direction.South);
           }
           if(randomGenerator.Next(0,4) == 1)
           {
               tempRoom.openDoor(Direction.East);
           }

        }   
        return tempRoom;     
    }
    public static Room newCorridor(Direction enteredFrom)
    {
        Room tempRoom = new Corridor();
        int count = 1;  //enteredFrom is always true;
        tempRoom.openDoor(enteredFrom);
        if(randomGenerator.Next(0,4) == 1)
        {
            tempRoom.openDoor(Direction.North);
            count++;
        }
        if(randomGenerator.Next(0,4) == 1)
        {
            tempRoom.openDoor(Direction.West);
            count++;
        }
        if(randomGenerator.Next(0,4) == 1)
        {
            tempRoom.openDoor(Direction.South);
            count++;
        }
        if(randomGenerator.Next(0,4) == 1)
        {
            tempRoom.openDoor(Direction.East);
            count++;
        }
        if(count == 1)
        {
            tempRoom.openDoor(Direction.West);
            tempRoom.openDoor(Direction.East);
        }
        if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.West) && tempRoom.DirectionIsOpen(Direction.South) && tempRoom.DirectionIsOpen(Direction.East))  //All
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "──┘ └──",
                "──┐ ┌──"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.West) && tempRoom.DirectionIsOpen(Direction.South))                                //Missing East
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "──┘ │  ",
                "──┐ │  "};
        }
        else if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.West))                                                                    //Missing South and East
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "──┘ │  ",
                "────┘  "};
        }
        else if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.West) && tempRoom.DirectionIsOpen(Direction.East))                                //Missing South
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "──┘ └──",
                "───────"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.East))                                                                    //Missing South and West
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "  │ └──",
                "  └────"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.North) && tempRoom.DirectionIsOpen(Direction.East) && tempRoom.DirectionIsOpen(Direction.South))                                //Missing West
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "  │ └──",
                "  │ ┌──"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.South) && tempRoom.DirectionIsOpen(Direction.East))                                                                    //Missing West and North
        {
            tempRoom.mapDisplay = new String[]{
                "       ",
                "  ┌────",
                "  │ ┌──"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.East) && tempRoom.DirectionIsOpen(Direction.West) && tempRoom.DirectionIsOpen(Direction.South))                                //Missing North
        {
            tempRoom.mapDisplay = new String[]{
                "       ",
                "───────",
                "──┐ ┌──"};
        }
        else if(tempRoom.DirectionIsOpen(Direction.South) && tempRoom.DirectionIsOpen(Direction.West))                                                                    //Missing North and East
        {
            tempRoom.mapDisplay = new String[]{
                "       ",
                "────┐  ",
                "──┐ │  "};
        }
        else if(tempRoom.DirectionIsOpen(Direction.South) && tempRoom.DirectionIsOpen(Direction.North))                                                                    //Missing West and East
        {
            tempRoom.mapDisplay = new String[]{
                "  │ │  ",
                "  │ │  ",
                "  │ │  "};
        }
        else if(tempRoom.DirectionIsOpen(Direction.West) && tempRoom.DirectionIsOpen(Direction.East))                                                                    //Missing North and South
        {
            tempRoom.mapDisplay = new String[]{
                "       ",
                "───────",
                "───────"};
        }
        
        return tempRoom;     
    }
}
//TODO Rooms have there look taken from json file

//Varje väg kollar vad som är på båda sidor, väljer från det i en lista hur den ska se ut
//Checkar:
//1. Om båda har en väg dit (borde se tills på annat ställe att dom har det) ; Ifall båda har det gå vidare till 2 
//2. Är det korridor eller rum, välj utseende från det

//TODO vad händer om rumen är oupsökta, rum med allt öppet?, Igenfyllt?