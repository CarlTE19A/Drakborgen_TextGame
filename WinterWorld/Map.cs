using System.Numerics;
class Map
{
    static private Random randomGenerator = new Random();
    public static Vector2 mapSize = new Vector2(10, 10);
    public static void displayMap(Dictionary<Vector2, Room> rooms)  //This displays the map on the screen, used to show the player how he can move
    {
        int lineAmmount = (int)mapSize.Y * 4 + 1;
        String[] lines = new String[lineAmmount];
        lines[0] = "  ──────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬──────  ";
        for (var y = 1; y < lineAmmount - 1; y++)   //Checks the whole grid in y
        {
            if(y % 4 != 0)  //Makes the right side of the map solid
            {
                lines[y] += "│";
            }
            for (var x = 0; x < mapSize.X; x++)     //Checks the whole grid in x inside y
            {
                Vector2 pos = new Vector2(x, (y - 1) / 4);
                if(y % 4 == 0)  //Between rooms in the y direction
                {
                    if(x == 0)
                    {
                        lines[y] += "├";
                    }
                    if(rooms[pos].DirectionIsOpen(Direction.South) || rooms[pos + new Vector2(0,1)].DirectionIsOpen(Direction.North))   //Display walls between rooms in the y-axis
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
                    if(x < 9 && y < 9)
                    {
                        if(rooms[pos].DirectionIsOpen(Direction.South) || rooms[pos + new Vector2(0,1)].DirectionIsOpen(Direction.North))
                        {
                            rooms[pos].openDoor(Direction.South);
                            rooms[pos].recalculateRoom();
                            rooms[pos + new Vector2(0,1)].openDoor(Direction.North);
                            rooms[pos + new Vector2(0,1)].recalculateRoom();
                        }
                        if(rooms[pos].DirectionIsOpen(Direction.East) || rooms[pos + new Vector2(1,0)].DirectionIsOpen(Direction.West))
                        {
                            rooms[pos].openDoor(Direction.East);
                            rooms[pos].recalculateRoom();
                            rooms[pos + new Vector2(1,0)].openDoor(Direction.West);
                            rooms[pos + new Vector2(1,0)].recalculateRoom();
                        }
                    }
                    lines[y] += rooms[pos].displayRoom(y % 4 - 1);  //Display to innards of the room
                    if(x != 9)
                    {
                        if(rooms[pos].DirectionIsOpen(Direction.East) || rooms[pos + new Vector2(1,0)].DirectionIsOpen(Direction.West))     //Display walls between rooms in the x-axis
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
        tempRoom.recalculateRoom();
        
        return tempRoom;     
    }

}
//TODO Rooms have there look taken from json file

//Varje väg kollar vad som är på båda sidor, väljer från det i en lista hur den ska se ut
//Checkar:
//1. Om båda har en väg dit (borde se tills på annat ställe att dom har det) ; Ifall båda har det gå vidare till 2 
//2. Är det korridor eller rum, välj utseende från det

//TODO vad händer om rumen är oupsökta, rum med allt öppet?, Igenfyllt?