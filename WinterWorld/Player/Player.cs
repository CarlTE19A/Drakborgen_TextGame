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
        displayStats();
        //Show where player came from
        //Show Choises
        /*From Choise: (All only if possible)
        1. Show Inventory
        2. Go North
        3. Go East
        4. Go South
        5. Go West
        */
        Write.ColoredLine("Tip H : help", ConsoleColor.Yellow);
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
                case ConsoleKey.I:
                    Console.WriteLine("Opens Inventory");
                    hasChoosen = true;
                    break;
                case ConsoleKey.H:
                    Console.WriteLine("Arrows : Move");
                    Console.WriteLine("I : Open Inventory");
                    break;
            }
        }
        return false;   
    }
    void displayStats()
    {
        Write.Colored($"Player : {title}  ", ConsoleColor.DarkGreen);
        Write.Colored($"HP : {health}  ", ConsoleColor.Red);
        Write.ColoredLine($"Position : {pos}  ", ConsoleColor.Yellow);
    }
    void displayInventory()
    {
        Console.Clear();
        displayStats();
        //Show Inventory
    }
}

//Health (HP)
//Strength (ST)
//Agility (AG)
//Armor (AR)
//Psyke (PS)

//Be able to "vila" to regain HP