﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Figgle;

namespace Game
{
    public class Program
    {
        struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static bool specialEncounterOccurred = false;
        public static bool specialEncounter2Occurred = false;
        public static bool specialEncounter3Occurred = false;
        public static bool specialEncounter4Occurred = false;
        public static int RandomEncounterCount = 0;
        public static int SpecialEncounterCount = 0;
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                [DllImport("user32.dll")]
                static extern IntPtr GetForegroundWindow();
                [DllImport("user32.dll")]
                static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
                [DllImport("user32.dll")]
                static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
                [DllImport("user32.dll")]
                static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);
                const int SW_MAXIMIZE = 3;
                IntPtr consoleWindowHandle = GetForegroundWindow();
                ShowWindow(consoleWindowHandle, SW_MAXIMIZE);
                Rect screenRect;
                GetWindowRect(consoleWindowHandle, out screenRect);
                int width = screenRect.Right - screenRect.Left;
                int height = screenRect.Bottom - screenRect.Top;
                MoveWindow(consoleWindowHandle, screenRect.Left, screenRect.Top, width, height, true);
            }

            if(!Directory.Exists("saves/"))
            {
                Directory.CreateDirectory("saves/");
            }
            currentPlayer = Load(out bool newP);
            if(newP)
                Encounters.QueenEncounter();
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
            Console.Write("\x1b[1m");
            Console.Write(FiggleFonts.Graffiti.Render("<Welcome to>"));
            Console.WriteLine(FiggleFonts.Graffiti.Render("<Shadows of Eldoria!>"));
            Console.Write("\x1b[0m");
            Console.ResetColor();
            Console.Write("Press any key to continue\n>_");
            Tools.Loading();
            
            bool isNameValid = false;
            while (isNameValid == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\x1b[1m");
                Console.Write(FiggleFonts.Graffiti.Render("<What will your "));
                Console.WriteLine(FiggleFonts.Graffiti.Render("characters name be?>"));
                Console.Write("\x1b[0m");
                Console.ResetColor();

                p.Name = Tools.ReadLine();
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
                p.Id = i;
                Console.Clear();
                if (p.Name == "")
                {
                    isNameValid = false;
                }    
                else
                {
                    Console.Write("Are you sure your name is ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(p.Name);
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
                        Console.WriteLine(p.Name);
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
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("\nCenturies ago, Eldoria was ruled by a wise and just king, whose benevolent reign brought ");
            Console.WriteLine("peace and prosperity to the land. However, his sudden and mysterious death plunged the ");
            Console.WriteLine("kingdom into turmoil. The king's three heirs, each representing one of the noble virtues of ");
            Console.WriteLine("wisdom, courage, and honor, embarked on a treacherous journey to prove their worthiness ");
            Console.WriteLine("to ascend to the throne. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.Write("Your name is ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(p.Name+".");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You are one of the three knights who are the mightiest in all of Eldoria!");
            Console.WriteLine("The worker nearby in your room tells you quickly about about the tragedy happing in the land of Eldoria at this very moment.");
            Console.WriteLine("You rush and grab your sharpest sword, as you run towards the throne hall you hear screaming and yelling ");
            Console.WriteLine("'The king!', The king was murdered by a shadow!!, Help the castle is under attack!");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();


            return p;  
        }
        
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void Ending()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\x1b[1m");
            Console.Write(FiggleFonts.Graffiti.Render("<Thanks for playing!>"));
            Console.WriteLine(FiggleFonts.Graffiti.Render("<To be continued>"));
            Console.Write("\x1b[0m");
            Console.ResetColor();
            Console.Write("Press any key to continue\n>_");
            Tools.Loading();
            Program.Quit();
        }

        //saves
        public static void Save()
        {
            string path = "saves/" + currentPlayer.Id.ToString() + ".player";
            string jsonString = JsonSerializer.Serialize(currentPlayer, new JsonSerializerOptions { IncludeFields = true});
            File.WriteAllText(path, jsonString);
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves/");
            List<Player> players = new List<Player>();
            int idCount=0;

            foreach (string p in paths)
            {
                string jsonString = File.ReadAllText(p);
                Player? player = JsonSerializer.Deserialize<Player>(jsonString, new JsonSerializerOptions { IncludeFields = true});
                if (player != null)
                {
                    players.Add(player);
                }
            }

            idCount = players.Count;

            while(true)
            {
                Console.Clear();
                Print("Choose your save:",50);
                
                foreach (Player p in players)
                {
                    Console.WriteLine(p.Id + ": " + p.Name);
                }
                Print("Please input player name or id (id:# or playername). 'create' will start a new save!", 20);
                string[] data = Tools.ReadLine().Split(':');

                try
                {
                    if(data.Length == 2 && data[0]=="id")
                    {
                        if(int.TryParse(data[1],out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.Id==id)
                                {
                                    currentPlayer = player;
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
                    else if(data.Length == 1 && data[0]=="create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        currentPlayer = newPlayer;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.Name==data[0])
                            {
                                currentPlayer = player;
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

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value*size);
            for(int i = 0; i < size; i++)
            {
                if(i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }
    }
}