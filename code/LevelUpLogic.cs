using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game {
    public class LevelUpLogic {
        public static void levelUpLogic(Player player) {
            while(player.CanLevelUp()) {
                player.xp -= player.GetLevelUpValue();
                player.level++;

                player.armorValue++;
                player.weaponValue++;
                player.potion+= 3;
                player.coins += 200;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Program.Print("Congrats! You are now level "+player.level+"!!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("You've been rewarded 200 coins, 3 potions!, 1 armor upgrade and 1 weapon upgrade!");
            Console.ResetColor();
        }
    }
}