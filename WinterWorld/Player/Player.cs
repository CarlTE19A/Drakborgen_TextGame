using System.Numerics;
public class Player : Character
{
    List<Direction> walkHistory = new List<Direction>();

    public Vector2 pos;
    public Player(Character choosenCharacter)
    {
        SetFromCharacter(choosenCharacter); //Make player be able to choose character from a couple of characters
    }
    public bool PlayerTurn(Dictionary<Vector2, Room> map)   //Return true if Dead
    {
        //Show Stats
        displayChacterTurn();
        bool hasChoosen = false;
        while (hasChoosen == false)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if(pos.Y > 0 && map[pos].DirectionIsOpen(Direction.North))
                    {
                        pos -= new Vector2(0, 1);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(pos.Y < 9 && map[pos].DirectionIsOpen(Direction.South))
                    {
                        pos += new Vector2(0, 1);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(pos.X > 0 && map[pos].DirectionIsOpen(Direction.West))
                    {
                        pos -= new Vector2(1, 0);
                        hasChoosen = true;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(pos.X < 9 && map[pos].DirectionIsOpen(Direction.East))
                    {
                        pos += new Vector2(1, 0);
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
        Console.WriteLine();
        Write.Colored($"     Player : {title}  ", ConsoleColor.DarkGreen);
        Write.Colored($"HP : {health}  ", ConsoleColor.Red);
        Write.ColoredLine($"Position : {pos}  ", ConsoleColor.Yellow);
        displayStats();
        Console.WriteLine("     Arrows : Move");
        Console.WriteLine("     TAB : Open Inventory");
    }
    void displayInventory()
    {
        Console.WriteLine("     Inventory:");
        Console.ReadKey(true);
    }
}