using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class DragonMalakarAfterCombatText {
        public static void dragonMalakarAfterCombatText() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("In the annals of antiquity, the interminable struggle at last drew its curtains with the vanquishing of the fearsome Dragon Malakar. ");
            Console.WriteLine("With a thunderous crash, the colossal dragon plummeted to the earth, releasing its death grip on Eldoria's besieged skies. ");
            Console.WriteLine("As its monstrous form lay still, an eerie mist that had enshrouded the land for so long dissipated, revealing an otherworldly, ");
            Console.WriteLine("ethereal presence that soared into the horizon, a spectral wraith fleeing the scene.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Amidst the lingering haze, one of your valiant knights intoned words of reassurance. ");
            Console.WriteLine("The malevolent miasma that had hung like a pall over the realm had at last evaporated, ");
            Console.WriteLine("and it became apparent that the kingdom of Eldoria had been liberated from the clutches of darkness.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("With hearts emboldened, you and your companions embarked upon the journey back to the venerable Castle of Eldoria, ");
            Console.WriteLine("where Queen and court awaited news of the epic clash. In the regal chambers, ");
            Console.WriteLine("you recounted the tale of your triumphant struggle against the unholy terror that had menaced the kingdom.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Eldoria's grateful populace, recognizing your indomitable valor, paid homage in a manner befitting heroes. ");
            Console.WriteLine("Three grand statues, one for each of you and your two faithful comrades, now grace the heart of the kingdom, standing as enduring symbols of your selfless heroism. ");
            Console.WriteLine("With this final act, the destiny of Eldoria was sealed, ensuring that the kingdom shall flourish throughout the ages.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Program.Ending();
        }
    }
}