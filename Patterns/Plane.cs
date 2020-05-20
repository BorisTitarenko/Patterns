using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Plane : FightComponent
    {
        public String Name { get; private set; }
        public List<Bomb> Bombs { get; set; }
        public List<Missle> Missles { get; set; }
        public List<Gun> Guns { get; set; }

        private PlainBuilder builder;

        public Plane(String name) {
            this.Name = name;
            context = new Context(new HangarPlainState());
        }

        public Plane(PlainBuilder builder) : this(builder.Plain.Name) {
            this.builder = builder;
            Bombs = builder.Bombs;
            Missles = builder.Missles;
            Guns = builder.Guns;
        }

        public void AddGun(Gun gun) {
            Guns.Add(gun);
        }

        public void AddMissle(Missle missle) {
            Missles.Add(missle);
        }

        public void AddBomb(Bomb bomb) {
            Bombs.Add(bomb);
        }

        public void ReplaceBomb(BombDecorator bombDecorator)
        {
            Bombs[Bombs.FindIndex(b => b.Equals(bombDecorator.Bomb))] = bombDecorator;
        }

        //Remove ...

        public override void AddFightComponent(FightComponent builder)
        {
            throw new NotImplementedException();
        }

        public override void RemoveFightComponent(FightComponent component)
        {
            throw new NotImplementedException();
        }

        public override FightComponent SendToWar()
        {
            Console.WriteLine(context.Request());
            Console.WriteLine(context.Request());
            return this;
        }

        public String GetStateStatus() {
            return context.GetStatus();
        }

        

        public override FightComponent GetFightComponent(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            Plane plane = (Plane)obj;
            return plane.Name.Equals(this.Name);
        }

        public override object Clone()
        {
            return new Plane(this.builder);
        }
    }
}
