using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;
            
            while(true)
            {
                potionP = 20+10*p.mods;
                armorP = 100*(p.armorValue+1);
                weaponP = 100*p.weaponValue;
                difP = 300+100*p.mods;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>=======Shop=======<>\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(W)eapon:         $\u001b[0m"+weaponP);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(A)rmor:          $\u001b[0m"+armorP);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(P)otions:        $\u001b[0m"+potionP);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(D)ifficulty Mod: $\u001b[0m"+difP);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(E)xit shop        |\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|(Q)uit Game        |\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(p.Name+"'s Stats");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Current Health:    |\u001b[0m"+p.health);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Coins:             |\u001b[0m"+p.coins);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Weapon Strength:   |\u001b[0m"+p.weaponValue);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Armor Toughness:   |\u001b[0m"+p.armorValue);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Potions:           |\u001b[0m"+p.potion);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Difficulty Mods:   |\u001b[0m"+p.mods);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Xp:\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("[");
                Program.ProgressBar("+","-",((decimal)p.xp/(decimal)p.GetLevelUpValue()),20);
                Console.WriteLine("]");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m|Level:             |\u001b[0m"+p.level);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\u001b[1m<>==================<>\u001b[0m");

                string input = Tools.ReadLine().ToLower();
                if(input=="w"||input=="weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if(input=="a"||input=="armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if(input=="p"||input=="potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if(input=="d"||input=="difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if(input=="q"||input=="quit")
                {
                    Program.Quit();
                }
                else if(input=="e"||input=="exit")
                    break;
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.coins>=cost)
            {
                if(item=="weapon")
                    p.weaponValue++;
                else if(item=="armor")
                    p.armorValue++;
                else if(item=="potion")
                    p.potion++;
                else if(item=="dif")
                    p.mods++;

                p.coins-=cost;
            }
            else
            {
                Console.WriteLine("insufficient coins!");
                Console.WriteLine("");
                Console.Write("Press any key to continue.\n>_");
                Tools.Loading();
            }
        }
    }
}