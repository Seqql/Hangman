using System;

namespace HangMan
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            bool restart = true;
            do
            {
                ScreenOptions.Buchstabe.Clear();
                ScreenOptions.Used.Clear();
                Start(ref restart);
            }
            while (restart);


            Console.ReadKey();
        }


        public static void Start(ref bool restart)
        {
            bool gewonnen = false;

            Console.WriteLine("Enter you word");

            ScreenOptions.read();

            while (!gewonnen)
            {
                ScreenOptions.check(ref gewonnen);
            }
            

            Console.WriteLine("Again?(y/n)");
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            Console.WriteLine();

            if (keyinfo.Key != ConsoleKey.Y)
                restart = false;

        }


    }
}
