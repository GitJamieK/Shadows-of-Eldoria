using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Encounters
    {   
        static Random rand =  new Random();
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
            string n = " ";
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
                    Console.WriteLine("with all your will and power you surge forth and slice your opnonent, as you swing your sword the "+n+" strikes back at you");
                    int damage = p - Program.currentPlayer.armorValue;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);
                    Console.WriteLine("You lose "+ damage + "health and deal "+attack+" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
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
                Console.ReadKey();
            } 
        }
    }
}
