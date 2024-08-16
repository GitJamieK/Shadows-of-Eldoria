using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class SpecialEncounterText {
        public static void specialEncounterText() {
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
            Console.WriteLine("It was one of the two mighty knights. ");
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
    }
}