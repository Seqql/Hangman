using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    class ScreenOptions
    {


        public static List<Wort> Buchstabe = new List<Wort>();
        public static List<string> Used = new List<string>();        
        public static int hangman = -1;
        //index.hangman =*
        //0.0 =|     | Correct
        //1.0 =|-----| Correct
        //2.1 =   |
        //3.1 =   |/
        //4.2 =   |------|
        //5.3 =   |/     O
        //6.4 =   |     \|/
        //7.5 =   |     / \ 


        public static void read()
        {
            Wort w;
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            Console.Clear();
            Console.WriteLine("  ");

            while (keyinfo.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                w = new Wort(Convert.ToString(keyinfo.Key));
                Buchstabe.Add(w);
                Console.WriteLine("");

                foreach (Wort item in Buchstabe)
                {
                    Console.Write("  " + item.Buchstabe);
                }

                keyinfo = Console.ReadKey();
            }



            if (keyinfo.Key != ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }

            Console.Clear();
            Console.WriteLine("");

            for (int i = 0; i < Buchstabe.Count; i++)
            {
                Console.Write("  _");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");

        }

        public static void check(ref bool? gewonnen)
        {
           
                

            //Prüft ob schon alle Buchstaben erraten sind
            if (check_all())
            {
                gewonnen = true;
                return;
            }

            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey();
            bool inWord = false;
            string s = Convert.ToString(keyInfo.Key);
            //Prüft ob der Buchstabe in dem Wort vorkommt
            foreach (var item in Buchstabe)
            {
                if (item.Buchstabe == s)
                {
                    item.IsCheck = true;
                    inWord = true;
                }
            }

            //Dokumentiert die genutzten Buchstaben (aber nur wenn sie nich im Wort vorkommen)
            if (!inWord)
            {
                if (Used.Count == 0)
                    Used.Add(s);
                else if(check_used(s))
                    Used.Add(s);

                hangman++;

                

            }
            
            Console.Clear();
            Console.WriteLine("  " + space(Used.Count) + drawhangman(4));

            //Schreibt die geschrieben Buchstaben 
            foreach (var item in Buchstabe)
            {
                if(item.IsCheck == true)
                    Console.Write("  " + item.Buchstabe);
                else
                    Console.Write("  _");
            }
            Console.Write("  " + space(Used.Count).Substring(0, space(Used.Count).Length - (Buchstabe.Count *3)) + drawhangman(3) + drawhangman(5));
            Console.WriteLine(Environment.NewLine + "  " + space(Used.Count) + drawhangman(2) + drawhangman(6)); 

            //Schreibt die schon genutzten Buchstaben
            foreach (var item in Used)
            {               
                Console.Write("  " + item);
            }

            
            Console.WriteLine("  " + space(Used.Count).Substring(0, space(Used.Count).Length - (Used.Count * 3)) + drawhangman(2) + drawhangman(7));
            Console.WriteLine("  " + space(Used.Count) + drawhangman(1));
            Console.WriteLine("  " + space(Used.Count) + drawhangman(0));


            if (hangman > 4)            
                gewonnen = null;
                
            
        }

        private static bool check_all()
        {
            bool b = true;
            foreach (var item in Buchstabe)
            {
                if (!item.IsCheck){                
                    b = false;
                    break;
                }                                
            }
            return b;
        }
        private static bool check_used(string s)
        {
            
            foreach (var item in Used)
            {
                if (item == s)
                    return false;
            }
            return true;
        }

        private static string drawhangman(int index)
        {
            if (index == 0 && hangman >= 0)//Correct
                return "|     |";
            else if (index == 1 && hangman >= 0)//Correct
                return "|-----|";
            else if (index == 2 && hangman >= 1) //Correct
                return "   |";
            else if (index == 3 && hangman >= 1) //Correct
                return "   |/";
            else if (index == 4 && hangman >= 2) //Correct
                return "   |------|";
            else if (index == 5 && hangman >= 3) //Correct
                return "     O";
            else if (index == 6 && hangman >= 4) //Correct
                return "     \\|/";
            else if (index == 7 && hangman >= 5) //Correct 
                return "     / \\";
            


            return "";
        }
        private static string space(int min)
        {
            string s = "";

            for (int i = 0; i < min * 3 + 10; i++)
            {
                s += " ";
            }

            if (s.Length <= 15)
            {
                s = "";
                for (int i = 0; i < 15; i++)
                {
                    s += " ";
                }
            }
            return s;
        }
    }
    }

