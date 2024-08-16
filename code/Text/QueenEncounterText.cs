using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class QueenEncounterText {
        public static void queenEncounterText() {
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
            Console.WriteLine("'Brave soul, your quest is dire. You must, with all haste, seek out the other two knights. Together, you three shall embark on a perilous journey to vanquish the malevolent shadow sorcerer known as 'Malakar'..");
            Console.WriteLine("..The fate of our realm rests upon your shoulders, and the kingdom's salvation lies within your valorous hearts.'");
            Console.WriteLine("");
            Console.WriteLine("'The malevolent sorcerer Malakar is manipulating events from the shadows. ");
            Console.WriteLine("He craved the ancient artifacts known as the Crystal Orbs, which were said to hold immense power capable of reshaping the very fabric of reality. ");
            Console.WriteLine("These orbs were scattered across Eldoria, protected by powerful enchantments and guarded by mythical creatures.'");
            Console.WriteLine("");
            Console.WriteLine("'So please mighty warrior search the other knights and find the crystal orbs and defeat Malakar before they summon the ancient evil, known as the Shadow Lord. ");
            Console.WriteLine("The awakening of the Shadow Lord would unleash an eternal darkness upon Eldoria.'");
            Console.WriteLine("");
            Console.WriteLine("'Before you go young knight, please prove your strength in a fight against me..'");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Encounters.Combat(false, "Queen",3,15);
            Encounters.QueenAfterCombat();
        }
    }
}