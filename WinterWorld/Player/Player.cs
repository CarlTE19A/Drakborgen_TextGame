using System.Numerics;
public class Player : Character
{
    List<Direction> walkHistory = new List<Direction>();

    Vector2 pos;
    public Player(Character choosenCharacter)
    {
        SetFromCharacter(choosenCharacter);
        //Make player be able to choose character from a couple of characters
    }
    public bool PlayerTurn()   //Return true if Dead
    {
        Console.Clear();
        //Show Stats
        displayChacterTurn();
        bool hasChoosen = false;
        while (hasChoosen == false)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if(pos + new Vector2(0, 1) == Vector2.Clamp(pos + new Vector2(0, 1), new Vector2(0,0), new Vector2(10,10)))
                    {
                        pos += new Vector2(0, 1);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(pos + new Vector2(1, 0) == Vector2.Clamp(pos + new Vector2(1, 0), new Vector2(0,0), new Vector2(10,10)))
                    {
                        pos += new Vector2(1, 0);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(pos + new Vector2(0, -1) == Vector2.Clamp(pos + new Vector2(0, -1), new Vector2(0,0), new Vector2(10,10)))
                    {
                        pos += new Vector2(0, -1);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(pos + new Vector2(-1, 0) == Vector2.Clamp(pos + new Vector2(-1, 0), new Vector2(0,0), new Vector2(10,10)))
                    {
                        pos += new Vector2(-1, 0);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.Tab:
                    displayInventory();
                    break;
            }
        }
        return false;   
    }
    void displayChacterTurn()
    {
        Write.Colored($"Player : {title}  ", ConsoleColor.DarkGreen);
        Write.Colored($"HP : {health}  ", ConsoleColor.Red);
        Write.ColoredLine($"Position : {pos}  ", ConsoleColor.Yellow);
        displayStats();
        Console.WriteLine("Arrows : Move");
        Console.WriteLine("TAB : Open Inventory");
    }
    void displayInventory()
    {
        Console.Clear();
        Console.WriteLine("Inventory");
        Console.ReadKey(true);
        Console.Clear();
        displayChacterTurn();
    }
}

//Health (HP)
//Strength (ST)
//Agility (AG)
//Armor (AR)
//Psyke (PS)

//Be able to "vila" to regain HP