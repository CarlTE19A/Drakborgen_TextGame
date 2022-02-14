using System.Numerics;
///<summary>Controls all of the displaying and creating of the map. (static)</summary>
static class Map 
{ 
    static private Random randomGenerator = new Random();
    public static Vector2 mapSize = new Vector2(10, 10);
    public static void displayMap(Dictionary<Vector2, Room> rooms, bool display, List<Player> players)  //This displays the map on the screen, used to show the player how he can move
    {
        int lineAmmount = (int)mapSize.Y * 4 + 1;
        String[] lines = new String[lineAmmount];
        Console.WriteLine();    //One line down
        Console.WriteLine();
        lines[0] = "       ──────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬──────  ";
        for (var y = 1; y < lineAmmount - 1; y++)   //Checks the whole grid in y
        {
            lines[y] += "     ";
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
                    if(rooms[pos].DirectionIsOpen(Direction.South) || rooms[pos + new Vector2(0,1)].DirectionIsOpen(Direction.North))   //Display openings between rooms in the y-axis
                    {
                        if(rooms[pos].GetType().Name == "Corridor" && rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")
                        {
                            lines[y] += "  │ │  ";
                            rooms[pos].openDoor(Direction.South);
                            rooms[pos].recalculateRoom();
                            rooms[pos + new Vector2(0,1)].openDoor(Direction.North);
                            rooms[pos + new Vector2(0,1)].recalculateRoom();
                        }
                        else if(rooms[pos].GetType().Name == "Corridor")
                        {
                            lines[y] += "──┘ └──";
                            rooms[pos].openDoor(Direction.South);
                            rooms[pos].recalculateRoom();
                        }
                        else if(rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")
                        {
                            lines[y] += "──┐ ┌──";
                            rooms[pos + new Vector2(0,1)].openDoor(Direction.North);
                            rooms[pos + new Vector2(0,1)].recalculateRoom();
                            
                        }
                        else
                        {
                            {
                                lines[y] += "──   ──";
                            }
                        }
                    }
                    else if(rooms[pos].GetType().Name == "Corridor" && rooms[pos + new Vector2(0,1)].GetType().Name == "Corridor")      //Display no wall between closed corridors
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
                else    //Display the rooms themself
                {
                    if(rooms[pos].DirectionIsOpen(Direction.North) && pos.Y > 0)
                    {
                        rooms[pos - new Vector2(0,1)].openDoor(Direction.South);
                        rooms[pos - new Vector2(0,1)].recalculateRoom();
                    }
                    if(rooms[pos].DirectionIsOpen(Direction.West) && pos.X > 0)
                    {
                        rooms[pos - new Vector2(1,0)].openDoor(Direction.East);
                        rooms[pos - new Vector2(1,0)].recalculateRoom();
                    }
                    if(rooms[pos].DirectionIsOpen(Direction.South) && pos.Y < 9)
                    {
                        rooms[pos + new Vector2(0,1)].openDoor(Direction.North);
                        rooms[pos + new Vector2(0,1)].recalculateRoom();
                    }
                    if(rooms[pos].DirectionIsOpen(Direction.East) && pos.X < 9)
                    {
                        rooms[pos + new Vector2(1,0)].openDoor(Direction.West);
                        rooms[pos + new Vector2(1,0)].recalculateRoom();
                    }
                    if(y % 4 - 1 == 1 && players.Count != 0)
                    {
                        string tempRoomDisplay = "";
                        char[] symbols = new char[3] {' ', ' ', ' '};
                        for (var i = 0; i < players.Count; i++)
                        {
                            if(pos == players[i].pos)
                            {
                                if(symbols[1] == ' ')
                                {
                                    symbols[1] = players[i].mapSymbol;
                                }
                                else if(symbols[0] == ' ')
                                {
                                    symbols[0] = players[i].mapSymbol;
                                }
                                else if(symbols[2] == ' ')
                                {
                                    symbols[2] = players[i].mapSymbol;
                                }
                                else
                                {
                                    Write.ColoredLine("More then 3 items at 1 position", ConsoleColor.Yellow);
                                }
                                tempRoomDisplay = rooms[pos].displayRoom(y % 4 - 1, symbols);  //Display to innards of the room with character
                            }
                            else if(i == players.Count-1 && symbols[0] == ' ' && symbols[1] == ' ' && symbols[2] == ' ')
                            {
                                tempRoomDisplay = rooms[pos].displayRoom(y % 4 - 1);  //Display to innards of the room with character
                            }
                        }
                        lines[y] += tempRoomDisplay;
                    }
                    else
                    {
                        lines[y] += rooms[pos].displayRoom(y % 4 - 1);  //Display to innards of the room
                    }
                    if(x != 9)
                    {
                        if(rooms[pos].DirectionIsOpen(Direction.East) || rooms[pos + new Vector2(1,0)].DirectionIsOpen(Direction.West))     //Display walls between rooms in the x-axis
                        {
                            rooms[pos].openDoor(Direction.East);
                            rooms[pos].recalculateRoom();
                            rooms[pos + new Vector2(1,0)].openDoor(Direction.West);
                            rooms[pos + new Vector2(1,0)].recalculateRoom();
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
        lines[lineAmmount - 1] = "       ──────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┴──────  ";

        if(display == true)
        { 
            foreach (var line in lines)
            {
                System.Console.WriteLine(line);   
            }
        }
    }
    public static Dictionary<Vector2, Room> createWorld(Vector2 worldInitSize)        //Old better create world during game
{
    Dictionary<Vector2, Room> worldInitGrid = new Dictionary<Vector2, Room>();  //World Dictonary for all rooms
    Room roomForNext = newRoom(true, Direction.North);
    for (var x = 0; x < worldInitSize.X; x++)
    {
        for (var y = 0; y < worldInitSize.Y; y++)
        {
            if(randomGenerator.Next(0,6) == 1)
            {   
                roomForNext = newCorridor();
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
    public static Room newCorridor()
    {
        Room tempRoom = new Corridor();
        switch (randomGenerator.Next(0,11))
                {
                    case 0:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.South);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 1:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.South);
                        break;
                    case 2:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.West);
                        break;
                    case 3:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 4:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 5:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.South);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 6:
                        tempRoom.openDoor(Direction.South);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 7:
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.South);
                        tempRoom.openDoor(Direction.East);
                        break;
                    case 8:
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.South);
                        break;
                    case 9:
                        tempRoom.openDoor(Direction.North);
                        tempRoom.openDoor(Direction.South);
                        break;
                    case 10:
                        tempRoom.openDoor(Direction.West);
                        tempRoom.openDoor(Direction.East);
                        break;
                }
        tempRoom.recalculateRoom();
        
        return tempRoom;     
    }

}
//TODO vad händer om rumen är oupsökta, rum med allt öppet?, Igenfyllt?