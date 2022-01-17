public class Corridor : Room
{
    public void InitCorridor()
    {

        //Makes open entrance a direction thats not entrance and if everything goes wrong north
        Direction? openDirection = null;
        while(openDirection != entrance && openDirection != null)
        {
            Array values = Enum.GetValues(typeof(Direction));
            openDirection = (Direction)values.GetValue(generator.Next(values.Length));
        }
        openDoors[openDirection ?? Direction.North] = true;
        //if(openDoors == Direction.North)
    }
    public void EnterCorridor()
    {
        //Set player at room with openDirection
    }

    public static String[,] mapDisplay = new String[,]
    {
        {
            "  │ │  ",
            "──┘ └──",
            "──┐ ┌──"
        },
        {
        
            "       ",
            "       ",
            "       "
        }
    };
}
