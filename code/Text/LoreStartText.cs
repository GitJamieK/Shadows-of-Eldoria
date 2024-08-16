using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class LoreStartText {
        public static void loreStartText(Player p) {
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
        }
    }
}