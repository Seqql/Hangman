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
            bool? gewonnen = false;

            Console.WriteLine("Enter you word");

            ScreenOptions.read();

            while (gewonnen == false)
            {
                ScreenOptions.check(ref gewonnen);
            }
            
            if(gewonnen == true)
                Console.WriteLine("Gewonnen!");
            else if(gewonnen == null)
                Console.WriteLine("Verloren!");

            Console.WriteLine("Again?(y/n)");
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            Console.WriteLine();

            if (keyinfo.Key != ConsoleKey.Y)
                restart = false;

        }


    }
}
