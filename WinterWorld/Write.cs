 public static class Write
 {
     static ConsoleColor standardForegroundColor = ConsoleColor.White;
     static ConsoleColor standardBackgroundColor = ConsoleColor.Black;
     public static void SetupColor()   //Fixes colors to standard
     {
         Console.ForegroundColor = standardForegroundColor;
         Console.BackgroundColor = standardBackgroundColor;
         Console.WriteLine(" ");
         Console.Clear();
     }
     public static void ColoredLine(string text, ConsoleColor color)
     {
         if(color != standardBackgroundColor)
         {
             Console.ForegroundColor = color;
         }        
         Console.WriteLine(text);
         Console.ForegroundColor = standardForegroundColor;
     }
     public static void Colored(string text, ConsoleColor color)
     {
         Console.ForegroundColor = color;
         Console.Write(text);
         Console.ForegroundColor = standardForegroundColor;
     }
 }