using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Encounters
    {   
        static Random rnd =  new Random();
        //Encounter Generic


        //Encounters
        public static void QueenEncounter()
        {
            Console.Clear();
            Console.WriteLine("TMEP_TMEP"); //wait, Write story.
            Console.WriteLine("TMEP_TMEP"); //wait, Write story.
            Console.ReadKey();
            Combat(false, "Queen",5,2); //TEMP STATS
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You hear something behind you, you turn and see a...");
            Console.ReadKey();
            Combat(true,"",0,0); //values are placeholders
        }
        public static void WarriorEncounter() //TEMP
        {
            Console.Clear();
            Console.WriteLine("You encounter a Shadow warrior!");
            Console.WriteLine("IT ATTACKS!");
            Console.WriteLine("Press any key to continue\n>");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Shadow Warrior",1,4);

        }
        public static void PuzzleOneEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are walking down a hall. You see that the floor is covered in runes.");
            List<char> runes = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char targetRune = runes[Program.rnd.Next(0, 8)];
            runes.Remove(targetRune);
    
            int targetRow = Program.rnd.Next(0, 4);
    
            for (int row = 0; row < 4; row++)
            {
                
                for (int col = 0; col < 4; col++)
                {
                    char runeToShow = (row == targetRow) ? targetRune : runes[Program.rnd.Next(0, 7)];
                    Console.Write($" [{runeToShow}] ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Choose your path: (Enter the row number where you want to stand, 1-4)");
            if (int.TryParse(Tools.ReadLine(), out int selectedRow) && selectedRow >= 1 && selectedRow <= 4)
            {
                if (selectedRow == targetRow + 1)
                {
                    Console.WriteLine("You have successfully crossed the hallway!");
                }
                else
                {
                    Console.WriteLine("Darts fly out of the walls! You take 2 damage.");
                    Program.currentPlayer.health -= 2;
                    if (Program.currentPlayer.health <= 0)
                    {
                        // Death
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You start to feel sick. The poison from the darts slowly kills you. You have died!");
                        Console.ResetColor();
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Input: Enter a whole number between 1 and 4.");
            }

            Console.ReadKey();
        }
        public static void NewStaticEncounter()
        {
            Console.Clear();
            Console.WriteLine("TEMP");
            // add story
            // add story
            Console.ReadKey();
        }
        
        //Encounter tools
        public static void RandomEncounter()
        {
            switch(rnd.Next(0,3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WarriorEncounter();
                    break;
                case 2:
                    PuzzleOneEncounter();
                    break;
            }
            
            Program.RandomEncounterCount++;
            if (Program.RandomEncounterCount >= 20)
            {
                NewStaticEncounter();
                Program.RandomEncounterCount = 0;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {   
            string n = " ";
            int p = 0;
            int h = 0;
            if (random)
            {   
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\u001b[1m<>=======================<>\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\u001b[1m||\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(n);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\u001b[1m<>=======================<>\u001b[0m");
                Console.ResetColor();
                Console.WriteLine("Power: "+p+"  health: "+h);
                Console.WriteLine("         .-.            ");
                Console.WriteLine("       __|=|__          ");
                Console.WriteLine("      (_/`-`\\_)        ");
                Console.WriteLine("      //\\___/\\\\      ");
                Console.WriteLine("      <>/   \\<>        ");
                Console.WriteLine("       \\|_._|/         ");
                Console.WriteLine("        <_I_>           ");
                Console.WriteLine("         |||            ");
                Console.WriteLine("        /_|_\\          ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m| (A)ttack (D)efend |\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|   (R)un    (H)eal |\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                Console.WriteLine("Potions: "+Program.currentPlayer.potion+" Health: "+Program.currentPlayer.health);
                string input = Tools.ReadLine();
                if (input.ToLower() == "a"||input.ToLower()=="attack")
                {
                    //Attack
                    Console.WriteLine("with all your will and power you surge forth and slice your opnonent, as you swing your sword the "+n+" strikes back at you");
                    int damage = p - Program.currentPlayer.armorValue;
                    if(damage<0)
                        damage=0;
                    int attack = rnd.Next(0, Program.currentPlayer.weaponValue) + rnd.Next(1,4)+((Program.currentPlayer.currentClass==Player.PLayerClass.Warrior)?3:0);
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
                    int attack = rnd.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose "+damage+" health and deal "+attack+" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;                    
                }
                else if (input.ToLower() == "r"||input.ToLower()=="run")
                {
                    //Run
                    if(Program.currentPlayer.currentClass!=Player.PLayerClass.Archer&&rnd.Next(0,2) == 0)
                    {
                        //fail run
                        Console.WriteLine("You Decide to take a chance and run a way from "+n+", unfortunately the incoming strike hits you in the back and you fall on the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose "+damage+" health and you did not manage to run away from"+n+".");
                        Program.currentPlayer.health-=damage;
                    }
                    else
                    {
                        //succed run
                        Console.WriteLine("You decide to take a chance and run away from "+n+", you manage to evade the incoming blow and successfully get away.");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
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
                        int potionV = 5+((Program.currentPlayer.currentClass==Player.PLayerClass.Mage)?+4:0);
                        Console.WriteLine("You gain "+potionV+" health");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion--;
                        Console.WriteLine("As you were drinking the potion, the "+n+" snuck up on you and stuck.");
                        int damage = (p/2)-Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose "+damage+" health");
                    }
                }
                if(Program.currentPlayer.health<=0)
                {
                    //death
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("As the "+n+" stands tall above you as you faint and your vision turns black. You have been killed by the "+n);
                    Console.ResetColor();
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("\nAs you stand victorious over the dead "+n+" you find "+c+" gold coins!\nYou have gained "+x+"XP!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.LevelUp();

            
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch(rnd.Next(0,4))
            {
                case 0:
                    return "Small Shadow Warrior";
                case 1:
                    return "Big Shadow Warrior";
                case 2:
                    return "Huge Shadow Warrior";
                case 3:
                    return "Giant Shadow Warrior";
                case 4:
                    return "MINIBOSS Shadow Warrior";
            }
            return "Shadow Warrior";
        }
    }
}
