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
            Console.WriteLine("You encounter a Shadow warrior!");
            Console.WriteLine("IT ATTACKS!");
            Console.WriteLine("Press any key to continue\n>");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Shadow warrior",1,4);
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
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p+"/"+h);
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
                    if(damage<0)
                        damage=0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);
                    Console.WriteLine("You lose "+damage+" health and deal "+attack+" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d"||input.ToLower()=="defend")
                {
                    //Defend
                    Console.WriteLine("As the "+n+" goes in for a strike, you ready your sword in a defensive stance and block the blow.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if(damage<0)
                        damage=0;                    
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose "+damage+" health and deal "+attack+" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;                    
                }
                else if (input.ToLower() == "r"||input.ToLower()=="run")
                {
                    //Run
                    if(rand.Next(0,2) == 0)
                    {
                        //fail run
                        Console.WriteLine("You Decide to take a chance and run a way from "+n+", unfortunately the incoming strike hits you in the back and you fall on the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose "+damage+" health and you did not manage to run away from"+n+".");
                        Console.ReadKey();
                    }
                    else
                    {
                        //succed run
                        Console.WriteLine("You decide to take a chance and run away from "+n+", you manage to evade the incoming blow and successfully get away.");
                        Console.ReadKey();
                        //go to store/home/castle
                    }
                }
                else if (input.ToLower() == "h"||input.ToLower()=="heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion==0)
                    {
                        //fail heal
                        Console.WriteLine("As you desperatly in need of a potion grasp for a potion in your bag, all that you can feel are empty flasks already used.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("The "+n+" manages to strike you with a mighty blow while you were trying to heal yourself and you lose "+damage+" health");
                    }
                    else
                    {
                        //succed heal
                        Console.WriteLine("You quickly reach into your bag and pull out a brightly glowing, purple flask. You take a long refreshing drink.");
                        int potionV = 5;
                        Console.WriteLine("You gain "+potionV+" health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were drinking the potion, the"+n+"snuck up on you and stuck.");
                        int damage = (p/2)-Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose "+damage+" health");
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
            } 
        }
    }
}
