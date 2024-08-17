using System;
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
using Game;

namespace Game {
    public class CombatLogic {
        public static void combatLogic(bool random, Player player, Random rnd, string name, int power, int health) {
                        string n = " ";
            int p = 0;
            int h = 0;

            string Queen = @"
.
                  .       |         .    .
            .  *         -*-          *
                 \        |         /   .
.    .            .      /^\     .              .    .
   *    |\   /\    /\  / / \ \  /\    /\   /|    *
 .   .  |  \ \/ /\ \ / /     \ \ / /\ \/ /  | .     .
         \ | _ _\/_ _ \_\_ _ /_/_ _\/_ _ \_/
           \  *  *  *   \ \/ /  *  *  *  /
            ` ~ ~ ~ ~ ~  ~\/~ ~ ~ ~ ~ ~ '
            ";
            string DragonMalakar = @"
                            ==(W{==========-      /===-                        
                              ||  (.--.)         /===-_---~~~~~~~~~------____  
                              | \_,|**|,__      |===-~___                _,-' `
                 -==\\        `\ ' `--'   ),    `//~\\   ~~~~`---.___.-~~      
             ______-==|        /`\_. .__/\ \    | |  \\           _-~`         
       __--~~~  ,-/-==\\      (   | .  |~~~~|   | |   `\        ,'             
    _-~       /'    |  \\     )__/==0==-\<>/   / /      \      /               
  .'        /       |   \\      /~\___/~~\/  /' /        \   /'                
 /  ____  /         |    \`\.__/-~~   \  |_/'  /          \/'                  
/-'~    ~~~~~---__  |     ~-/~         ( )   /'        _--~`                   
                  \_|      /        _) | ;  ),   __--~~                        
                    '~~--_/      _-~/- |/ \   '-~ \                            
                   {\__--_/}    / \\_>-|)<__\      \                           
                   /'   (_/  _-~  | |__>--<__|      |                          
                  |   _/) )-~     | |__>--<__|      |                          
                  / /~ ,_/       / /__>---<__/      |                          
                 o-o _//        /-~_>---<__-~      /                           
                 (^(~          /~_>---<__-      _-~                            
                ,/|           /__>--<__/     _-~                               
             ,//('(          |__>--<__|     /                  .----_          
            ( ( '))          |__>--<__|    |                 /' _---_~\        
         `-)) )) (           |__>--<__|    |               /'  /     ~\`\      
        ,/,'//( (             \__>--<__\    \            /'  //        ||      
      ,( ( ((, ))              ~-__>--<_~-_  ~--____---~' _/'/        /'       
    `~/  )` ) ,/|                 ~-_~>--<_/-__       __-~ _/                  
  ._-~//( )/ )) `                    ~~-'_/_/ /~~~~~~~__--~                    
   ;'( ')/ ,)(                              ~~~~~~~~~~                         
  ' ') '( (/                                                                   
    '   '  `
            ";
            string NormalEnemie = @"
         .-.            
       __|=|__          
      (_/`-`\_)        
      //\___/\\      
      <>/   \<>        
       \|_._|/         
        <_I_>           
         |||            
        /_|_\          
        ";
            if (random) {   
                n = Encounters.GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else {
                n = name;
                p = power;
                h = health;
            }
            while (h>0) {
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Power: "+p+"  health: "+h);
                Console.ResetColor();
                if (name == "DragonMalakar") {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(DragonMalakar);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m| (A)ttack (D)efend |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m|   (R)un    (H)eal |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                }
                else if (name == "Queen") {
                    Console.WriteLine(Queen);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m| (A)ttack (D)efend |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m|   (R)un    (H)eal |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                }
                else {
                    Console.WriteLine(NormalEnemie);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m| (A)ttack (D)efend |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m|   (R)un    (H)eal |\u001b[0m");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Potions: "+Program.currentPlayer.potion+" Health: "+Program.currentPlayer.health);
                Console.WriteLine("Armor: "+Program.currentPlayer.armorValue+" Weapon: "+Program.currentPlayer.weaponValue);
                Console.ResetColor();
                int pAttack = Program.currentPlayer.weaponValue + rnd.Next(2,5)+((Program.currentPlayer.currentClass==Player.PLayerClass.Warrior)?4:0);
                string input = Tools.ReadLine();
                if (input.ToLower() == "a"||input.ToLower()=="attack") {
                    //Attack
                    Console.WriteLine("with all your will and power you surge forth and slice your opponent, as you swing your sword the "+n+" strikes back at you");
                    int damage = p - Program.currentPlayer.armorValue;
                    if(damage<0)
                        damage=0;
                    int attack = rnd.Next(0, Program.currentPlayer.weaponValue) + rnd.Next(1,4)+((Program.currentPlayer.currentClass==Player.PLayerClass.Warrior)?3:0);
                    Console.WriteLine("You lose "+damage+" health and deal "+attack+" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d"||input.ToLower()=="defend") {
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
                else if (input.ToLower() == "r"||input.ToLower()=="run") {
                    //Run
                    if(Program.currentPlayer.currentClass!=Player.PLayerClass.Archer&&rnd.Next(0,2) == 0) {
                        //fail run
                        Console.WriteLine("You Decide to take a chance and run a way from "+n+", unfortunately the incoming strike hits you in the back and you fall on the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose "+damage+" health and you did not manage to run away from"+n+".");
                        Program.currentPlayer.health-=damage;
                    }
                    else {
                        //succed run
                        Console.WriteLine("You decide to take a chance and run away from "+n+", you manage to evade the incoming blow and successfully get away.");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h"||input.ToLower()=="heal") {
                    //Heal
                    if (Program.currentPlayer.potion==0) {
                        //fail heal
                        Console.WriteLine("As you desperatly in need of a potion grasp for a potion in your bag, all that you can feel are empty flasks already used.");
                        int damage = p - Program.currentPlayer.armorValue;
                        Program.currentPlayer.health -= p;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("The "+n+" manages to strike you with a mighty blow while you were trying to heal yourself and you lose "+damage+" health");
                    }
                    else {
                        //succed heal
                        Console.WriteLine("You quickly reach into your bag and pull out a brightly glowing, purple flask. You take a long refreshing drink.");
                        int potionV = 5+((Program.currentPlayer.currentClass==Player.PLayerClass.Mage)?+4:0);
                        Console.WriteLine("You gain "+potionV+" health");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion--;
                        if (rnd.Next(0,2) == 0) {
                            int damage = (p/2)-Program.currentPlayer.armorValue;
                            if(damage<0)
                                damage=0;
                            Console.WriteLine("As you were drinking the potion, the "+n+" snuck up on you and stuck.");
                            Console.WriteLine("You lose "+damage+" health");
                            Program.currentPlayer.health -= damage;
                        }
                    }
                }
                if(Program.currentPlayer.health<=0) {
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
    }
}