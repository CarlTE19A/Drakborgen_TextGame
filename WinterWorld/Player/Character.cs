using System.Text.Json;
public class Character
{
    static string charactersFile = "player/characters.json";
    //All public for the newPlayers Function to set values correctly
    public string title {get; set;}
    public int health {get; set;}
    public int strength {get; set;}
    public int psyche {get; set;}
    public int agility {get; set;}
    public int armor {get; set;}
    public string description {get; set;}
    public Character()
    {
        
    }
    protected void SetFromCharacter(Character choosenCharacter)   //To Copy the Character from preset to new Player
    {
        title = choosenCharacter.title;
        health = choosenCharacter.health;
        strength = choosenCharacter.strength;
        psyche = choosenCharacter.psyche;
        agility = choosenCharacter.agility;
        armor = choosenCharacter.armor;
        description = choosenCharacter.description;
    }
    public void displayStats()
    {
        Console.Write("<");
        Write.Colored($"Strength : {strength}, ", ConsoleColor.Red);
        Write.Colored($"Psyche : {psyche}, ", ConsoleColor.Magenta);
        Write.Colored($"Agility : {agility}, ", ConsoleColor.Cyan);
        Write.Colored($"Armor : {armor}", ConsoleColor.Blue);
        Console.WriteLine(">");
    }
    public static List<Player> newPlayers()
    {
        
        int playerAm = Choose.Int(1, 4, "How many players are there?", true);
        Console.WriteLine("How many players are there? (1-4)");
        Console.Clear();
        Write.ColoredLine($"There are {playerAm} player(s)", ConsoleColor.Cyan);
        List<Player> tempPlayers = new List<Player>();
        List<Character> characters = new List<Character>();
        try
        {
        string jsonFromFile = File.ReadAllText("player/characters.json");
        characters = JsonSerializer.Deserialize<List<Character>>(jsonFromFile);
        //Console.WriteLine(characters[0].strength);
        }
        catch (System.Exception)
        {
            Console.WriteLine("Missing File");
            Console.ReadKey();
            Environment.Exit(2);
        }
        for (var i = 0; i < playerAm; i++)
        {
            Console.WriteLine("Player " + (i+1));
            for (var j = 0; j < characters.Count; j++)
            {
                Console.WriteLine(j+1 + " : " + characters[j].title);
                characters[j].displayStats();
            }
            Console.WriteLine($"Choose a character (1 - {characters.Count})");
            int choosenValue = Choose.Int(1, characters.Count)-1;
            tempPlayers.Add(new Player(characters[choosenValue]));
            characters.RemoveAt(choosenValue);
            Console.Clear();
        }
        Console.WriteLine("Players");
        for (var i = 0; i < playerAm; i++)
        {
            Console.Write($"Player {i+1} : {tempPlayers[i].title}");
            tempPlayers[i].displayStats();
            //TODO fixa stats och displaya som table
        }
        Console.ReadKey(true);
        return tempPlayers;
    }
}
//Characters loaded to be able to choose characters for players, then player is vertion of character