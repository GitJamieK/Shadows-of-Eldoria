using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;

namespace Game {
    public class Encounters {   
        static Random rnd =  new Random();
        //Encounter Generic

        //Encounters
        public static void QueenEncounter() { //encounter: queen
            QueenEncounterText.queenEncounterText();
        }
        public static void QueenAfterCombat() {
            QueenAfterCombatText.queenAfterCombatText();
        }
        public static void BasicFightEncounter() {
            Console.Clear();
            Console.WriteLine("You hear something behind you, you turn and see a...");
            Console.ReadKey();
            Combat(true,"",0,0); //values are placeholders
        }
        public static void WarriorEncounter() {
            Console.Clear();
            Console.WriteLine("You encounter a Shadow warrior!");
            Console.WriteLine("IT ATTACKS!");
            Console.Write("Press any key to continue\n>_");
            Tools.Loading();
            Console.Clear();
            Combat(false, "Shadow Warrior",1,4);
        }
        public static void PuzzleOneEncounter() { //encounter: rune puzzle
            PuzzleOneEncounterText.puzzleOneEncounterText();
        }
        public static void SpecialEncounter() { //encounter: second knight
            SpecialEncounterText.specialEncounterText();
        }
        public static void SpecialEncounter2() { //encounter: third knight
            SpecialEncounter2Text.specialencounter2Text();
        }
        public static void SpecialEncounter3() {//encounter: ORBS
            SpecialEncounter3text.specialEncounter3Text();
        }
        public static void SpecialEncounter4() {//encounter: BOSS
            SpecialEncounter4Text.specialencounter4Text();
        }
        public static void DragonMalakarAfterCombat() {
            DragonMalakarAfterCombatText.dragonMalakarAfterCombatText();
        }
        
        //Encounter tools
        public static void RandomEncounter() {
            switch(rnd.Next(0,3)) {
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
            if (!Program.specialEncounterOccurred) {
                if (Program.RandomEncounterCount >= 10) {
                    SpecialEncounter();
                    Program.specialEncounterOccurred = true;
                    Program.SpecialEncounterCount++;
                }
            }
            else {
                if (Program.RandomEncounterCount >= 20) {
                    if (!Program.specialEncounter2Occurred) {
                        SpecialEncounter2();
                        Program.specialEncounter2Occurred = true;
                        Program.SpecialEncounterCount++;
                    }
                    else {
                        if (Program.RandomEncounterCount >= 30) {
                            if (!Program.specialEncounter3Occurred) {
                                SpecialEncounter3();
                                Program.specialEncounter3Occurred = true;
                                Program.SpecialEncounterCount++;
                            }
                            else {
                                if (Program.RandomEncounterCount >= 40) {
                                    if (!Program.specialEncounter4Occurred) {
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

        public static void Combat(bool random, string name, int power, int health) {   
            CombatLogic.combatLogic(random, Program.currentPlayer, rnd, name, power, health);
        }

        public static string GetName() {
            switch(rnd.Next(0,4)) {
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
