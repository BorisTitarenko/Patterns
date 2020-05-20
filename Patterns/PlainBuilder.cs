using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public abstract class PlainBuilder
    {
        public Plane Plain { get; set; }
        public List<Gun> Guns;
        public List<Bomb> Bombs;
        public List<Missle> Missles;
        public PlainBuilder(String name) {
            this.Plain = new Plane(name);
            this.Missles = new List<Missle>();
            this.Guns = new List<Gun>();
            this.Bombs = new List<Bomb>();
        }

        public abstract PlainBuilder AddGuns(List<Gun> guns);
        public abstract PlainBuilder AddBombs(List<Bomb> bombs);
        public abstract PlainBuilder AddMissles(List<Missle> missles);

        public Plane Build() { return new Plane(this); }

    }

    public class UserPlainBuider : PlainBuilder{
        public UserPlainBuider(String name) : base(name) { }
        public override PlainBuilder AddGuns(List<Gun> guns) {
            if (guns != null) { this.Guns.AddRange(guns); }
            return this;
        }

        public override PlainBuilder AddMissles(List<Missle> missles)
        {
            if (missles != null) { this.Missles.AddRange(missles); }
            return this;
        }

        public override PlainBuilder AddBombs(List<Bomb> bombs)
        {
            if (bombs != null) { this.Bombs.AddRange(bombs); }
            return this;
        }
    }

}
