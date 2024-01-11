
using System;

//using var game = new MonogameGamesSource.Game1.Game1();
using var game = new MonogameGamesSource.Game2.Game2();
game.Run();


/*
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class Program
{
    [DllImport("kernel32.dll")]
    static extern bool AllocConsole();

    [STAThread]
    static void Main(string[] args)
    {
        AllocConsole();

        Console.WriteLine("Game 1 or 2? ");
        int gameNumber;
        bool isNumber = Int32.TryParse(Console.ReadLine(), out gameNumber);

        if (!isNumber)
        {
            Console.WriteLine("Invalid input. Please enter a number. Exiting...");
            return;
        }

        switch (gameNumber)
        {
            case 1:
                using (var game = new MonogameGamesSource.Game1.Game1())
                    game.Run();
                break;
            case 2:
                // Uncomment the following lines when Game2 is available
                /*using (var game = new MonogameGamesSource.Game2())
                    game.Run();
break;
// Add more cases as needed
default:
                Console.WriteLine("Invalid game number. Exiting...");
break;
        }
    }
}
*/