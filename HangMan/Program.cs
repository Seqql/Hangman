using System;

namespace HangMan
{
    class Program
    {
        public static void Main(string[] args)
        {
            ScreenOptions so = new ScreenOptions();

            Console.ForegroundColor = ConsoleColor.Green;
            bool restart = true;
            do
            {
                so.Buchstabe.Clear();
                so.Used.Clear();
                Start(ref restart);
            }
            while (restart);


            Console.ReadKey();
        }


        public static void Start(ref bool restart)
        {
            bool? gewonnen = false;
            ScreenOptions so = new ScreenOptions();

            Console.WriteLine("Enter you word");

            so.read();

            while (gewonnen == false)
            {
                so.check(ref gewonnen);
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
