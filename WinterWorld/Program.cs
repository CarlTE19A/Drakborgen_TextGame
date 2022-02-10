using System.Numerics;
using System.Text.Json;
using static Write;

SetupColor();

Console.WriteLine();
ColoredLine("     ▓█████▄  ██▀███   ▄▄▄       ██ ▄█▀ ▄▄▄▄    ▒█████   ██▀███    ▄████ ▓█████  ███▄    █ ", ConsoleColor.DarkRed);
ColoredLine("     ▒██▀ ██▌▓██ ▒ ██▒▒████▄     ██▄█▒ ▓█████▄ ▒██▒  ██▒▓██ ▒ ██▒ ██▒ ▀█▒▓█   ▀  ██ ▀█   █ ", ConsoleColor.DarkRed);
ColoredLine("     ░██   █▌▓██ ░▄█ ▒▒██  ▀█▄  ▓███▄░ ▒██▒ ▄██▒██░  ██▒▓██ ░▄█ ▒▒██░▄▄▄░▒███   ▓██  ▀█ ██▒", ConsoleColor.DarkRed);
ColoredLine("     ░▓█▄   ▌▒██▀▀█▄  ░██▄▄▄▄██ ▓██ █▄ ▒██░█▀  ▒██   ██░▒██▀▀█▄  ░▓█  ██▓▒▓█  ▄ ▓██▒  ▐▌██▒", ConsoleColor.DarkRed);
ColoredLine("     ░▒████▓ ░██▓ ▒██▒ ▓█   ▓██▒▒██▒ █▄░▓█  ▀█▓░ ████▓▒░░██▓ ▒██▒░▒▓███▀▒░▒████▒▒██░   ▓██░", ConsoleColor.DarkRed);
ColoredLine("      ▒▒▓  ▒ ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░▒ ▒▒ ▓▒░▒▓███▀▒░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ░▒   ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ", ConsoleColor.DarkRed);
ColoredLine("      ░ ▒  ▒   ░▒ ░ ▒░  ▒   ▒▒ ░░ ░▒ ▒░▒░▒   ░   ░ ▒ ▒░   ░▒ ░ ▒░  ░   ░  ░ ░  ░░ ░░   ░ ▒░", ConsoleColor.DarkRed);
ColoredLine("      ░ ░  ░   ░░   ░   ░   ▒   ░ ░░ ░  ░    ░ ░ ░ ░ ▒    ░░   ░ ░ ░   ░    ░      ░   ░ ░ ", ConsoleColor.DarkRed);
ColoredLine("        ░       ░           ░  ░░  ░    ░          ░ ░     ░           ░    ░  ░         ░ ", ConsoleColor.DarkRed);
ColoredLine("      ░                                      ░                                             ", ConsoleColor.DarkRed);

Dictionary<Vector2, Room> worldGrid = Map.createWorld(Map.mapSize);
    //Force corners of map to be open in all directions
worldGrid[new Vector2(0,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,0)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(0,9)] = Map.newRoom(true, Direction.North);
worldGrid[new Vector2(9,9)] = Map.newRoom(true, Direction.North);
Map.displayMap(worldGrid, false, new List<Player>());      //Has repairations when displaying map so starts by displaying it without actully showing it
Console.ReadKey(true);
Console.Clear();
List<Player> players = Character.newPlayers();  //Create List of all players

while (true)
{
    foreach (var player in players)
    {
        Console.Clear();
        Map.displayMap(worldGrid, true, players);
        player.PlayerTurn(worldGrid);
        while(worldGrid[player.pos].GetType().Name == "Corridor")
        {
            Console.Clear();
            Map.displayMap(worldGrid, true, players);
            player.PlayerTurn(worldGrid);
        }
    }
}
//IDEA Enemys, weapons, traps are items that can all be found in normal rooms 
//Treature are seprate that you get from treature hall (can only be one?) or by defeating monsters 
//Endast olika stridsklasser kanske 
//TODO fixa stats och displaya som table