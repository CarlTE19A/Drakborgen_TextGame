using System.Numerics;
using System.Text.Json;
Console.SetWindowPosition(0,0);
//Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

Write.SetupColor();

Console.WriteLine("Press any key to Start");
Console.WriteLine("┌──   ──┬───────┐  │ │  ┌──   ──┐");
Console.WriteLine("│       │ x     │  │ │  │       │");
Console.WriteLine("│   ?           └──┘ └──┘   ?   │");
Console.WriteLine("│       │     T ┌──┐ ┌──┐       │");
Console.WriteLine("├──   ──┼───────┼──┤ │  ├──   ──┤");
Console.WriteLine("│       │       │  │ │  │       │");
Console.WriteLine("│   ?       x   └──┘ └──┤   ?   │");
Console.WriteLine("│       │       ┌───────┤       │");
Console.WriteLine("└───────┴───────┘       └──   ──┘");
Dictionary<Vector2, Room> worldGrid = Map.createWorld(Map.mapSize);
worldGrid[new Vector2(0,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(0,9)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,9)] = Map.newRoom(true, Direction.North);
Map.displayMap(worldGrid);
List<Player> players = Character.newPlayers();

while (true)
{
    foreach (var player in players)
    {
        player.PlayerTurn();
    }
}
Console.ReadKey(true);

void newRoom(Vector2 pos)
{
    if(!worldGrid.ContainsKey(pos))
    {
        worldGrid.Add(pos, new Room());
    }
}

//IDEA Enemys, weapons, traps are items that can all be found in normal rooms
//Treature are seprate that you get from treature hall (can only be one?) or by defeating monsters
//Endast olika stridsklasser kanske

//TODO fixa stats och displaya som table