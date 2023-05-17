using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Encounters
    {   
        //Encounter Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You encounter ....");
            Console.WriteLine("IT ATTACKS!");
            Console.WriteLine("Press any key to continue\n>");
            Console.ReadKey();
            Console.Clear();
        }

        //Encounter tools
        public static void Combat(bool random, string name, int power, int health)
        {   
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {   

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h>0)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un    (H)eal |");
                Console.WriteLine("--------------------");
                Console.WriteLine("  Potions: "+Program.currentPlayer.potion+"  Health: "+Program.currentPlayer.health);
                string input = Tools.ReadLine();
                if (input.ToLower() == "a"||input.ToLower()=="attack")
                {
                    //Attack
                    Console.WriteLine(""); // https://youtu.be/EURyF4U5OKw?t=1742
                }
                else if (input.ToLower() == "d"||input.ToLower()=="defend")
                {
                    //Defend

                }
                else if (input.ToLower() == "r"||input.ToLower()=="run")
                {
                    //Run

                }
                else if (input.ToLower() == "h"||input.ToLower()=="heal")
                {
                    //Heal

                }
            } 
        }
    }
}