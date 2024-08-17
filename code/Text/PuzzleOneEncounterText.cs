using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game {
    public class PuzzleOneEncounterText {
        public static void puzzleOneEncounterText() {
            Console.Clear();
            Console.WriteLine("You are walking down a hall. You see that the floor is covered in runes.");
            List<char> runes = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char targetRune = runes[Program.rnd.Next(0, 8)];
            runes.Remove(targetRune);

            int targetRow = Program.rnd.Next(0, 4);

            for (int row = 0; row < 4; row++) {
                for (int col = 0; col < 4; col++) {
                    char runeToShow = (row == targetRow) ? targetRune : runes[Program.rnd.Next(0, 7)];
                    Console.Write($" [{runeToShow}] ");
                }
                Console.WriteLine();
            }

            int selectedRow = 0;
            bool validInput = false;

            while (!validInput) {
                Console.Write("Choose your path: (Enter the row number where you want to stand, 1-4): ");
                if (int.TryParse(Tools.ReadLine(), out selectedRow) && selectedRow >= 1 && selectedRow <= 4) {
                    validInput = true;
                }
                else {
                    Console.WriteLine("Invalid Input: Enter a whole number between 1 and 4.");
                }
            }

            if (selectedRow == targetRow + 1) {
                Console.WriteLine("You have successfully crossed the hallway!");
            }
            else {
                Console.WriteLine("Darts fly out of the walls! You take 2 damage.");
                Program.currentPlayer.health -= 2;
                if (Program.currentPlayer.health <= 0) {
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
    }
}