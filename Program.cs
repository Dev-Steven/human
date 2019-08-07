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
        protected int health;
         
        // add a public "getter" property to access health
        public int Health
        {
            get { return health; }
            set { health = value; }
    
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
        public virtual int Attack(Human target)
        {
            target.health = target.health - 5*this.Strength;
            return target.health;
        }
    }

    class Wizard : Human
    {
        public Wizard(string Name) : base(Name)
        {
            this.Intelligence = 25;
            this.health = 50;
        }

        public Wizard(string Name, int Strength, int Intelligence, int Dexterity, int health) : base(Name)
        {
            this.Strength = Strength;
            this.Intelligence = Intelligence;
            this.Dexterity = Dexterity;
            this.health = health;
        }

        public override int Attack(Human target)
        {
            target.Health = target.Health - 5*this.Intelligence;
            this.health += target.Health; 
            System.Console.WriteLine($"Wizard now adding {target.Health}... total health is {this.health}");
            return this.health;
        }

        public void Heal(Human target)
        {
            target.Health += 10*this.Intelligence;
            System.Console.WriteLine($"{target.Name}'s health is now {target.Health}");
        }
    }

    class Ninja : Human
    {
        public Ninja(string Name) : base(Name)
        {
            this.Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            Random rand = new Random();
            int random = rand.Next(1,6);
            int more_damage =0;
            System.Console.WriteLine($"Random number generated is {random}");

            if(random == 1) 
            {
                System.Console.WriteLine("more_damage is now 10");
                more_damage = 10;
            }

            System.Console.WriteLine($"Dexterity: {this.Dexterity}");

            System.Console.WriteLine($"Attacking with {5*this.Dexterity + more_damage}  attack points");

            target.Health = target.Health - 5*this.Dexterity + more_damage;
            System.Console.WriteLine($"{target.Name}'s health is now {target.Health}");
            return this.Health;
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            this.health += 5;
        }
    }

    class Samurai : Human
    {
        public Samurai(string Name) : base(Name)
        {
            this.health = 200;
        }

        public Samurai(string Name, int Strength) : base(Name)
        {
            this.Strength = Strength;
        }

        public override int Attack(Human target)
        {
            System.Console.WriteLine($"{target.Name}'s health is {target.Health}");
            base.Attack(target);
            if(target.Health < 50)
            {
                target.Health = 0;
            }
            System.Console.WriteLine($"{target.Name} got attacked. Health is now {target.Health}");
            return target.Health;
        }

        public void Meditate()
        {
            this.health = 200;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wiz = new Wizard("Teng");
            Wizard wiz2 = new Wizard("Kian", 5, 5, 4, 99);
            Ninja nin1 = new Ninja("Angelo");
            Samurai sam = new Samurai("Sam");
            Samurai sam2 = new Samurai("Alex", 10);
            System.Console.WriteLine($"Wizard's Name: {wiz.Name} Strength: {wiz.Strength} Intelligence: {wiz.Intelligence} Health: {wiz.Health}");
            System.Console.WriteLine($"Samurai's Name: {sam.Name} Strength: {sam.Strength} Intelligence: {sam.Intelligence} Health: {sam.Health}");
            wiz.Attack(sam);
            System.Console.WriteLine($"Sam's heath: {sam.Health}");
            System.Console.WriteLine($"Ninja's Name: {nin1.Name}");
            nin1.Attack(wiz);
            sam2.Attack(wiz2);
            wiz.Heal(wiz2);

        }
    }

}
