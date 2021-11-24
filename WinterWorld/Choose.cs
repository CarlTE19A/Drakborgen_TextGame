static class Choose
{
    public static int Int(int min, int max)
    {
        if(min > max)
        {
            return min;
        }
        int value = min-1;
        while (value < min || value > max)
        {
            string input = Console.ReadLine();
            Int32.TryParse(input, out value);
        }
        return value;
    }
    public static int Int(int min, int max, string prompt, bool displayRange)
    {
        if(min > max)
        {
            return min;
        }
        int value = min-1;
        while (value < min || value > max)
        {
            if(displayRange)
            {
                Console.WriteLine(prompt + $" ({min} - {max})");
            }
            else
            {
                Console.WriteLine(prompt);
            }
            string input = Console.ReadLine();
            Int32.TryParse(input, out value);
            Console.Clear();
        }
        return value;
    }
}