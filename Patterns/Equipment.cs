using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public interface IEquipment {
        void ShowPower(); //Changing functionality for decorator
    }
    public abstract class Missle : IEquipment
    {
        public String Name { get; private set; }
        public int AIM { get; private set; } //I don't know about what this field

        public Missle(String name, int AIM) {
            this.Name = name;
            this.AIM = AIM;
        }

        public abstract void ShowPower();

       
    }

    public abstract class Bomb : IEquipment {
        public String Name { get; private set; }
        public float Weight { get; private set; }

        public Bomb(String name, float weignt) {
            this.Name = name;
            this.Weight = weignt;
        }

        public abstract void ShowPower();
       
    }

    public abstract class Gun : IEquipment {
        public String Name { get; private set; }
        public float Calibr { get; private set; }

        public Gun(String name, float calibr) {
            this.Name = name;
            this.Calibr = calibr;
        }
        public abstract void ShowPower();
       
    }


    public class MiniGun : Gun {

        public MiniGun(String name, float calibr) : base(name, calibr){ 
           
        }
        public override void ShowPower() {
            Console.WriteLine("Trrrrrrrrr, I'm MiniGun");
        }
    }

    public class AirMissle : Missle
    {
        public AirMissle(String name, int aim) : base(name, aim) { }
        public override void ShowPower()
        {
            Console.WriteLine("I'm flying, prepare your anus");
        }
    }


    public class SimpleBomb : Bomb {
        public SimpleBomb(String name, float weight) : base(name, weight){ }
        public override void ShowPower()
        {
            Console.WriteLine("Boom!");
        }

    }

    public abstract class BombDecorator : Bomb {  //Decorator
        public Bomb Bomb { get; private set; }
        public BombDecorator(Bomb bomb) : base(bomb.Name, bomb.Weight) {
            this.Bomb = bomb;
        }
    }

    public class AtomicBombDecorator : BombDecorator { 
        public AtomicBombDecorator(Bomb bomb) : base(bomb) { }

        public override void ShowPower() {
            Bomb.ShowPower();
            Console.WriteLine("Hirosima Sucks");
        }
    }

    public class ChemistryBombDecorator : BombDecorator {
        ChemistryBombDecorator(Bomb bomb) : base(bomb) { }
        public override void ShowPower()
        {
            Bomb.ShowPower();
            Console.WriteLine("Vietcong Sucks");
        }
    }


}
