using System.Numerics;
using System.Text.Json;
Vector2 mapSize = new Vector2(10, 10);
Write.SetupColor();

Console.WriteLine("Press any key to Start");
List<Player> players = newPlayers();
//Console.ReadKey(true);
Dictionary<Vector2, Room> worldGrid;    // = createWorld(mapSize);
Console.Clear();
//Player player = new Player();
//while (true)
//{
//    player.PlayerTurn();
//}
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
List<Player> newPlayers()    //Choose how many players there are
{
    Console.WriteLine("How many players are there? (1-4)");
    int playerAm = 0;
    while(playerAm <= 0 || playerAm >= 5)
    {
        playerAm = Console.ReadKey(true).KeyChar - '0'; //Value of char - char value of 0
    }
    Console.Clear();
    Write.ColoredLine($"There are {playerAm} player(s)", ConsoleColor.Cyan);
    List<Player> tempPlayers = new List<Player>();
    List<Character> characters = new List<Character>();
    try
    {
    string jsonFromFile = File.ReadAllText("player/characters.json");
    characters = JsonSerializer.Deserialize<List<Character>>(jsonFromFile);
         
    }
    catch (System.Exception)
    {
        Console.WriteLine("VITAL ERROR");
    }
    foreach (var person in characters)
    {
        Console.WriteLine(person.title);
    }
    Console.ReadLine();
    

    /*
    for (var i = 0; i < playerAm; i++)
    {
        tempPlayers.Add(new Player());
    }
    */

    return tempPlayers;
}
//IDEA Enemys, weapons, traps are items that can all be found in normal rooms
//Treature are seprate that you get from treature hall (can only be one?) or by defeating monsters