using System;

namespace human
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
         
        // add a public "getter" property to access health
        public int Health
        {
            get { return health; }
        }
         
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string Name)
        {
            this.Name = Name;
            this.Strength = 3;
            this.Intelligence = 3;
            this.Dexterity = 3;
            this.health = 100;
        }
         
        // Add a constructor to assign custom values to all fields
        public Human(string Name, int Strength, int Intelligence, int Dexterity, int health)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Intelligence = Intelligence;
            this.Dexterity = Dexterity;
            this.health = health;
        }
         
        // Build Attack method
        public int Attack(Human target)
        {
            target.health = target.health - 5*this.Strength;
            return target.health;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }

}
