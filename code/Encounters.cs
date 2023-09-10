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
        public static void QueenEncounter() //encounter: queen
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mThe Queen\u001b[0m");
            Console.WriteLine("\u001b[1m---------\u001b[0m");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Once through the grand entrance, you find yourself in the resplendent throne hall, \nits towering stone walls adorned with rich tapestries and flickering torches that cast dancing shadows upon the cold stone floor. ");
            Console.WriteLine("The air is heavy with a sense of urgency, as if the very walls themselves could whisper the dire straits of the realm. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("At the heart of the hall, upon a magnificent throne carved from oak and adorned with intricate designs, sits the queen. ");
            Console.WriteLine("Her countenance is a mixture of sorrow and determination, a reflection of the burdens she carries as the ruler of this embattled kingdom. ");
            Console.WriteLine("Her regal attire, once a symbol of power, now seems to hang upon her form as if weighed down by the troubles that surround her. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("You found yourself standing before The Queen, her regal presence casting a solemn aura about the room. ");
            Console.WriteLine("With a heart filled with unwavering loyalty, you knelt before her and uttered, ");
            Console.WriteLine("'My Lady, what tasks must I undertake to safeguard our realm?'");
            Console.WriteLine("");
            Console.WriteLine("Her Majesty, her eyes like gleaming sapphires, did not hesitate. She, the protector of the kingdom and the bearer of its destiny, swiftly replied, ");
            Console.WriteLine("'Brave soul, your quest is dire. You must, with all haste, seek out the other two knights. Together, you three shall embark on a perilous journey to vanquish the malevolent shadow sorcerer known as 'Malakar.'..");
            Console.WriteLine("..The fate of our realm rests upon your shoulders, and the kingdom's salvation lies within your valorous hearts.'");
            Console.WriteLine("");
            Console.WriteLine("'The malevolent sorcerer Malakar is manipulating events from the shadows. ");
            Console.WriteLine("He craved the ancient artifacts known as the Crystal Orbs, which were said to hold immense power capable of reshaping the very fabric of reality. ");
            Console.WriteLine("These orbs were scattered across Eldoria, protected by powerful enchantments and guarded by mythical creatures.'");
            Console.WriteLine("");
            Console.WriteLine("'So Please mighty warrior search the other knights and find the crystal orbs and defeat Malakar before they summon the ancient evil, known as the Shadow Lord. ");
            Console.WriteLine("The awakening of the Shadow Lord would unleash an eternal darkness upon Eldoria.'");
            Console.WriteLine("");
            Console.WriteLine("'Before you go young knight, please prove your strength in a fight againts me..'");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Combat(false, "Queen",5,15);
            QueenAfterCombatText();
        }
        public static void QueenAfterCombatText()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.WriteLine("'Fret not, valiant warrior, for I am yet among the living, not succumbed to the grasp of death's cold hand. ");
            Console.WriteLine("You've proven your strength and are able to fight alongside the other mighty warriors to defeat Malakar and the Shadow Lord once and for all.");
            Console.WriteLine("Please accept this gift as gratidute for you offering yourself and trying to save this kingdom..'");
            Program.currentPlayer.coins += 200;
            Program.currentPlayer.potion += 10;
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("You've been rewarded 200 coins and 10 potions!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Take your leave, valiant champion, and be the savior of this cherished realm we all hold dear!'");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
        }

        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You hear something behind you, you turn and see a...");
            Console.ReadKey();
            Combat(true,"",0,0); //values are placeholders
        }
        public static void WarriorEncounter()
        {
            Console.Clear();
            Console.WriteLine("You encounter a Shadow warrior!");
            Console.WriteLine("IT ATTACKS!");
            Console.Write("Press any key to continue\n>_");
            Tools.Loading();
            Console.Clear();
            Combat(false, "Shadow Warrior",1,4);

        }
        public static void PuzzleOneEncounter() //encounter: rune puzzle
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

            int selectedRow = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Choose your path: (Enter the row number where you want to stand, 1-4): ");
                if (int.TryParse(Tools.ReadLine(), out selectedRow) && selectedRow >= 1 && selectedRow <= 4)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input: Enter a whole number between 1 and 4.");
                }
            }

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

            Console.ReadKey();
        }
        public static void SpecialEncounter() //encounter: second knight
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("In the waning light of day, as the sun cast long shadows across the ancient realm, ");
            Console.WriteLine("your eyes were drawn to a figure, distant yet intriguing. With measured steps, you ");
            Console.WriteLine("ventured forth, each footfall echoing through the hallowed forest. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("As you drew near, the stranger turned to face you. Their countenance was shrouded ");
            Console.WriteLine("in mystery, but there was no mistaking the aura of strength that enveloped them. ");
            Console.WriteLine("It was one of the twoi mighty knights. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("With bated breath, you recounted the quest entrusted to you by the benevolent queen. ");
            Console.WriteLine("The warrior's eyes gleamed with understanding as the weight of your mission settled upon them. ");
            Console.WriteLine("Wordlessly, you both embarked on a solemn journey, for destiny had woven your fates together in the quest for the elusive third and final warrior, ");
            Console.WriteLine("the key to unlocking the ancient crystal orbs.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
        }
        public static void SpecialEncounter2() //encounter: third knight
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("TEMP");
            //ADD STORY (3RD KNIGHT)
            //ADD STORY (3RD KNIGHT)
        }
        public static void SpecialEncounter3() //encounter: ORBS
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("TEMP ORBS");
            //ADD STORY (ORBS)
            //ADD STORY (ORBS)
        }
        public static void SpecialEncounter4() //encounter: BOSS
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("TEMP BOSS");
            //ADD STORY (BOSS)
            //ADD STORY (BOSS)
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
            
            bool specialEncounterOccurred = false;
            bool specialEncounter2Occurred = false;
            Program.RandomEncounterCount++;
            if (!specialEncounterOccurred)
            {
                if (Program.RandomEncounterCount >= 5)
                {
                    SpecialEncounter();
                    specialEncounterOccurred = true;
                }
            }
            if (specialEncounterOccurred && !specialEncounter2Occurred)
            {
                if (Program.RandomEncounterCount >= 10)
                {
                    SpecialEncounter2();
                    specialEncounter2Occurred = true;
                }
            }
            if (specialEncounter2Occurred)
            {
                if (Program.RandomEncounterCount >= 15)
                {
                    //SpecialEncounter3();
                }
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
                int pAttack = Program.currentPlayer.weaponValue + rnd.Next(1,4)+((Program.currentPlayer.currentClass==Player.PLayerClass.Warrior)?3:0);
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
                        Program.currentPlayer.health -= p;
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
                        if (rnd.Next(0,2) == 0)
                        {
                            int damage = (p/2)-Program.currentPlayer.armorValue;
                            if(damage<0)
                                damage=0;
                            Console.WriteLine("As you were drinking the potion, the "+n+" snuck up on you and stuck.");
                            Console.WriteLine("You lose "+damage+" health");
                            Program.currentPlayer.health -= damage;
                        }
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
