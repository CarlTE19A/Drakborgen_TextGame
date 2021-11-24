public class Enemy : Item
{
    //Strength beats psyche
    //Psycke beats agility
    //Agility beats armor
    //Armor beats strength
    public int health {get; set;}
    public int strength {get; set;}
    public int psyche {get; set;}
    public int agility {get; set;}
    public int armor {get; set;}
}