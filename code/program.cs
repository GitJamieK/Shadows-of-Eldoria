using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Game
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if(newP)
                Encounters.FirstEncounter();
            while(mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }


        static Player NewStart(int i)
        {
            //choosing name
            Console.Clear();
            Player p = new Player();
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
            
            p.name = Tools.ReadLine();
            Print("Class: Mage  Archer  Warrior");
            bool flag = false;
            while(flag==false)
            {
                flag=true;
                string input = Tools.ReadLine().ToLower();
                if(input=="mage")
                    p.currentClass = Player.PLayerClass.Mage;
                else if(input=="archer")
                    p.currentClass = Player.PLayerClass.Archer;
                else if(input=="warrior")
                    p.currentClass = Player.PLayerClass.Warrior;
                else
                {
                    Console.WriteLine("Please choose an existing class!");
                    flag = false;
                }
            }
            p.id = i;
            Console.Clear();
                if (p.name == "")
                {
                    isNameValid = false;
                }    
                else
                {
                    Console.Write("Are you sure your name is ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(p.name);
                    Console.ResetColor();
                    Console.Write(" and that you are a ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(currentPlayer.currentClass);
                    Console.ResetColor();
                    Console.WriteLine();
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
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(p.name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\u001b[1m||<You are a \u001b[0m");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(currentPlayer.currentClass);
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
            Console.WriteLine("\u001b[1mStory introduction\u001b[0m");
            Console.WriteLine("\u001b[1m-------------------\u001b[0m");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("In the realm of Eldoria, a once prosperous and united kingdom, dark forces have begun to ");
            Console.WriteLine("stir. The land, once vibrant and thriving, is now shrouded in shadows and plagued by chaos. ");
            Console.WriteLine("The ancient prophecies speak of a time when a chosen hero will rise to confront the looming ");
            Console.WriteLine("darkness and restore balance to the realm. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("\nCenturies ago, Eldoria was ruled by a wise and just king, whose benevolent reign brought ");
            Console.WriteLine("peace and prosperity to the land. However, his sudden and mysterious death plunged the ");
            Console.WriteLine("kingdom into turmoil. The king's three heirs, each representing one of the noble virtues of ");
            Console.WriteLine("wisdom, courage, and honor, embarked on a treacherous journey to prove their worthiness ");
            Console.WriteLine("to ascend to the throne. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.Write("Your name is ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(p.name+".");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You are one of the three knights who are the mightiest in all of Eldoria!");
            Console.WriteLine("The worker nearby in your room tells you quickly about about the tragedy happing in the land of Eldoria at this very moment.");
            Console.WriteLine("You rush and grab your sharpest sword, as you run towards the throne hall you hear screaming and yelling ");
            Console.WriteLine("'The king!, The king was murdered by a shadow!!, Help the castle is under attack!");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();


            return p;
        }
        
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        //saves
        public static void Save()
        {
            string path = "saves/" + currentPlayer.id.ToString() + ".player";
            string jsonString = JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText(path, jsonString);
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount=0;

            foreach (string p in paths)
            {
                string jsonString = File.ReadAllText(p);
                Player? player = JsonSerializer.Deserialize<Player>(jsonString);
                if (player != null)
                {
                    players.Add(player);
                }
            }

            idCount = players.Count;

            while(true)
            {
                Console.Clear();
                Print("Choose your save:",60);
                
                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }
                Print("Please input player name or id (id:# or playername). 'create' will start a new save!", 60);
                string[] data = Tools.ReadLine().Split(':');

                try
                {
                    if(data[0]=="id")
                    {
                        if(int.TryParse(data[1],out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.id==id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue.\n>");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number!");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue.\n>");
                            Console.ReadKey();
                        }
                    }
                    else if(data[0]=="create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.name==data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.WriteLine("");
                        Console.Write("Press any key to continue.\n>");
                        Console.ReadKey();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue.\n>");
                    Console.ReadKey();
                }
            }
        }
        public static void Print(string text, int speed=40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine("");
        }
    }
}