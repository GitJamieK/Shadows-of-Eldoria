using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class QueenAfterCombatText {
        public static void queenAfterCombatText() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
    }
}