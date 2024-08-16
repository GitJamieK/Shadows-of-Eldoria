using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class SpecialEncounter4Text {
        public static void specialencounter4Text() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("In the time of relentless battles and the quaffing of elixirs, you and your fellow knights finally found a moment to catch your breath. ");
            Console.WriteLine("It was then that an ominous omen unfurled before your eyes. From the heavens above, a colossal, ebony beam descended, crashing to earth with a thunderous cacophony. ");
            Console.WriteLine("One of your knightly companions leaped to his feet, his countenance grave. 'By the ancient scrolls, that can be naught but the malevolent Malakar's gambit to invoke the Shadow Lord. ");
            Console.WriteLine("We must thwart him!' He spoke with an urgency that suggested the perilous closeness of the shadowy summoning.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Without a moment's hesitation, you surged toward the freshly fallen shaft of darkness. As you drew near, ");
            Console.WriteLine("an eerie aura coursed through your very veins, yet your resolve remained steadfast. You pressed onward, drawn inexorably toward the epicenter of the sinister beam. ");
            Console.WriteLine("The orbs in your possession began to radiate with an ever-intensifying luminosity. Your fellow knight declared, 'This must be the work of Malakar. We must vanquish him once and for all.'");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Upon your arrival, you beheld a disconcerting sight — a multitude of the same ominous obsidian haze enveloping a colossal dragon. ");
            Console.WriteLine("Astonishment seized all three of you, but your companion explained, 'Malakar has subjugated a dragon to augment his power.' ");
            Console.WriteLine("The orbs in your grasp blazed brilliantly, poised to unleash a cataclysmic surge of energy.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("With unwavering determination, you and your comrades clutched the orbs, ");
            Console.WriteLine("directing them toward the draconic embodiment of Malakar, ");
            Console.WriteLine("resolute in your mission to vanquish the dark sorcerer and safeguard the kingdom.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("In the face of Dragon Malakar, the shadow summoner, battle was joined!");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Encounters.Combat(false, "DragonMalakar",10,100);
            Encounters.DragonMalakarAfterCombat();
        }
    }
}