using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            Combat(false, "Queen",3,15);
            QueenAfterCombatText();
        }
        public static void QueenAfterCombatText()
        {
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
            Console.WriteLine("In the days of yore, as the sun dipped below the horizon, the valiant knight by your side, clad in armor resplendent, turned his gaze towards the darkening forest. ");
            Console.WriteLine("His visage spoke of ages spent in pursuit of the mystical and the arcane. ");
            Console.WriteLine("In a hushed tone, he whispered of a thunderous clamor that had echoed through the ancient woods, ");
            Console.WriteLine("a clamor that bore the promise of the third and final knight, fated to aid in the quest for the enigmatic crystal orbs. ");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Without hesitation, you both embarked on a perilous journey towards the source of that clamor. ");
            Console.WriteLine("There, amid gnarled trees and the eerie silence of twilight, lay the third knight, grievously wounded from a fierce and mighty battle. ");
            Console.WriteLine("The second knight among you, renowned for swiftness of action, rushed to their side, bearing two vials of life-restoring elixir.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("As the elixir coursed through the wounded knight's veins, strength returned to their battered form, and consciousness once more graced their eyes. ");
            Console.WriteLine("With purpose, you and the second knight imparted the royal quest that had been entrusted to you by the noble queen herself, the perilous mission to locate the legendary crystal orbs, ");
            Console.WriteLine("the only hope to vanquish the malevolent Malakar and safeguard the realm of Eldoria.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("With newfound unity and a shared sense of destiny, you set forth, your footsteps echoing through the haunted woods, ");
            Console.WriteLine("determined to find these elusive orbs and, in doing so, rewrite the fate of Eldoria.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
        }
        public static void SpecialEncounter3() //encounter: ORBS
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("In the midst of a relentless battle against the indomitable shadow warriors conjured forth by the malevolent sorcerer, Malakar, a peculiar revelation unfurled itself before your gallant trio. ");
            Console.WriteLine("Yonder, within the weathered stone walls, an enigmatic crevice beckoned, casting forth a faint, otherworldly luminescence. ");
            Console.WriteLine("You, being the astute soul, shared this extraordinary discovery with your two steadfast comrades. ");
            Console.WriteLine("Together, with valor in your hearts, you ventured closer to the beckoning aperture.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("One of your knightly companions, his eyes alight with astonishment, uttered a hushed conjecture that this might very well be the elusive sanctuary harboring the legendary crystal orbs.");
            Console.WriteLine("Though their whereabouts remained shrouded in mystery, whispers of their existence had long pervaded the realm.");
            Console.WriteLine("If these luminescent spheres were indeed the fabled orbs, then the murmurs held a kernel of truth.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("The trio, with hardly an inch to spare, squeezed through the narrow passage, arriving in a chamber of modest proportions. ");
            Console.WriteLine("Here, an imposing, circular stone portal obstructed the source of that ethereal azure radiance. ");
            Console.WriteLine("One of your stalwart allies posited that, if the lore proved reliable, a concealed mechanism must be concealed within this chamber.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("You, ever vigilant, espied a peculiar stone upon the wall, its visage ever so subtly distinct from the surrounding stones. ");
            Console.WriteLine("Sharing your find with your comrades, they urged you to manipulate it. ");
            Console.WriteLine("With a resolute press, the ponderous stone gateway glided aside, unveiling a mesmerizing sight - the resplendent, cerulean-glowing crystal orbs.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("The awe that gripped your trio, however, yielded swiftly to the sobering reality of your quest. ");
            Console.WriteLine("This realm teetered on the precipice of calamity, and the fate of the kingdom now hung heavy upon your shoulders. ");
            Console.WriteLine("Without delay, each of you claimed one of the radiant orbs, resolved to confront the malevolent Malakar and consign his reign of madness to history's annals.");
            Console.ResetColor();
            Console.Write("Press any key to continue.\n>_");
            Tools.Loading();
        }
        public static void SpecialEncounter4() //encounter: BOSS
        {
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
            Combat(false, "DragonMalakar",10,100);
            DragonMalakarAfterCombatText();
        }
        public static void DragonMalakarAfterCombatText()
        {
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
            
            Program.RandomEncounterCount++;
            if (!Program.specialEncounterOccurred)
            {
                if (Program.RandomEncounterCount >= 10)
                {
                    SpecialEncounter();
                    Program.specialEncounterOccurred = true;
                    Program.SpecialEncounterCount++;
                }
            }
            else
            {
                if (Program.RandomEncounterCount >= 20)
                {
                    if (!Program.specialEncounter2Occurred)
                    {
                        SpecialEncounter2();
                        Program.specialEncounter2Occurred = true;
                        Program.SpecialEncounterCount++;
                    }
                    else
                    {
                        if (Program.RandomEncounterCount >= 30)
                        {
                            if (!Program.specialEncounter3Occurred)
                            {
                                SpecialEncounter3();
                                Program.specialEncounter3Occurred = true;
                                Program.SpecialEncounterCount++;
                            }
                            else
                            {
                                if (Program.RandomEncounterCount >= 40)
                                {
                                    if (!Program.specialEncounter4Occurred)
                                    {
                                        SpecialEncounter4();
                                        Program.specialEncounter4Occurred = true;
                                        Program.SpecialEncounterCount++;
                                    }
                                }
                            }
                        }
                    }
                }   
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {   
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Power: "+p+"  health: "+h);
                Console.ResetColor();
                if (name == "DragonMalakar")
                {
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
                else if (name == "Queen")
                {
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
                else
                {
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
