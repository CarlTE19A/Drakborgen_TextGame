using System.Numerics;
using System.Text.Json;
Console.SetWindowPosition(0,0);
//Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

Write.SetupColor();

Dictionary<Vector2, Room> worldGrid = Map.createWorld(Map.mapSize);

    //Force corners of map to be open in all directions
worldGrid[new Vector2(0,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(0,9)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,9)] = Map.newRoom(true, Direction.North);

Map.displayMap(worldGrid);
Map.displayMap(worldGrid);
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