public class Character
{
    public string title {get; set;}
    protected int health {get; set;}
    protected int strength {get; set;}
    protected int psyche {get; set;}
    protected int agility {get; set;}
    protected int armor {get; set;}
    protected string description {get; set;}
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
}
//Characters loaded to be able to choose characters for players, then player is vertion of character