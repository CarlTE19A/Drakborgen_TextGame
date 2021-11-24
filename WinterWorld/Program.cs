using System.Numerics;
using System.Text.Json;
Vector2 mapSize = new Vector2(10, 10);

Write.SetupColor();

Console.WriteLine("Press any key to Start");
List<Player> players = Character.newPlayers();
Dictionary<Vector2, Room> worldGrid;    // = createWorld(mapSize);

Console.Clear();
while (true)
{
    foreach (var player in players)
    {
        player.PlayerTurn();
    }
}
Console.ReadKey(true);

Dictionary<Vector2, Room> createWorld(Vector2 worldInitSize)        //Old better create world during game
{
    Dictionary<Vector2, Room> worldInitGrid = new Dictionary<Vector2, Room>();  //World Dictonary for all rooms
    for (var x = 0; x < worldInitSize.X; x++)
    {
        for (var y = 0; y < worldInitSize.Y; y++)
        {
            worldInitGrid.Add(new Vector2(x,y), new Corridor());
        }
    }
    return worldInitGrid;
}

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