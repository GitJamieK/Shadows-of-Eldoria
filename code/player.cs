using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game {
    [Serializable]
    public class Player {
        private string? _name;
        public string? Name {
            get {
                return _name;
            }   
            set {
                _name = value;
            }
        }
        public int Id { get; set; }
        public int coins = 400;
        public int level = 1;
        public int xp = 0;
        public int health = 10;
        public int damage = 1; 
        public int armorValue = 0;
        public int potion = 7;
        public int weaponValue = 1;

        public int mods = 0;

        public enum PLayerClass {Mage, Archer, Warrior};
        public PLayerClass currentClass = PLayerClass.Warrior;

        public int GetHealth() {
            int upper = (2*mods+5);
            int lower = (mods+2);
            return Program.rnd.Next(lower,upper);
        }
        public int GetPower() {
            int upper = (2*mods+2);
            int lower = (mods+1);
            return Program.rnd.Next(lower,upper);
        }
        public int GetCoins() {
            int upper = (15*mods+50);
            int lower = (10*mods+10);
            return Program.rnd.Next(lower,upper);
        }

        public int GetXP() {
            int upper = (20*mods+70);
            int lower = (15*mods+20);
            return Program.rnd.Next(lower, upper);
        }

        public int GetLevelUpValue() {
            return 100*level+200;
        }

        public bool CanLevelUp() {
            if(xp>=GetLevelUpValue())
                return true;
            else
                return false;
        }

        public void LevelUp() {
            while(CanLevelUp()) {
                xp -= GetLevelUpValue();
                level++;

                armorValue++;
                weaponValue++;
                potion+= 3;
                coins += 200;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Program.Print("Congrats! You are now level "+level+"!!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("You've been rewarded 200 coins, 3 potions!, 1 armor upgrade and 1 weapon upgrade!");
            Console.ResetColor();
        }
    }
}