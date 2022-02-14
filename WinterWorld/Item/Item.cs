using System.Numerics;
public class Item
{
    public string Title {get; set;}    //Messege when you see the Item
    public string description {get; set;}
    static List<Enemy> enemies = new List<Enemy>();
    static List<Trap> traps = new List<Trap>();
    static List<Collectible> collectibles = new List<Collectible>();
}