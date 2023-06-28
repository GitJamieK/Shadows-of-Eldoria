using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
        }


        static void Start()
        {
            //choosing name

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m<>================================<>\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||<Welcome to Shadows of Eldoria!>||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m<>================================<>\u001b[0m");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();
            Console.Clear();
            
            bool isNameValid = false;
            while (isNameValid == false)
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m<>====================================<>\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||<What will your characters name be?>||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m||/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\||\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u001b[1m<>====================================<>\u001b[0m");
            Console.ResetColor();
            
            currentPlayer.name = Tools.ReadLine();
            Console.Clear();
                if (currentPlayer.name == "")
                {
                    isNameValid = false;
                }    
                else
                {
                    Console.WriteLine("Are you sure your name is "+ currentPlayer.name);
                    Console.WriteLine("Please type 'Yes' or 'No'");
                    string inputname = Tools.ReadLine();
                    if (inputname.ToLower() == "no")
                    {
                        isNameValid = false;
                        Console.Clear();
                    }

                    else if (inputname.ToLower() == "yes")
                    {
                        Console.Clear();
                        isNameValid = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\u001b[1m<>===========================<>\u001b[0m");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\u001b[1m||<Your name is \u001b[0m");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(currentPlayer.name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\u001b[1m<>===========================<>\u001b[0m");
                        Console.ResetColor();
                    }
                }    
            }
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();
            Console.Clear();

            //lore start

            Console.WriteLine("");
        }
    }
}