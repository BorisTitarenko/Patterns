using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Patterns
{
    public abstract class PlainFabric //Fabric + Template method
    {
        public abstract List<Gun> CreateGuns();
        public abstract List<Missle> CreateMissles();
        public abstract List<Bomb> CreateBombs();

        public Plane CreatePlain(String name) { //Template method
            return new UserPlainBuider(name)
                .AddMissles(CreateMissles())
                .AddBombs(CreateBombs())
                .AddGuns(CreateGuns())
                .Build();
        }
    }

    public class HornetFabric : PlainFabric
    {
        public override List<Bomb> CreateBombs()
        {
            return null;
        }

        public override List<Gun> CreateGuns()
        {
            return new List<Gun> { new MiniGun("MiniGun", 20) };
        }

        public override List<Missle> CreateMissles()
        {
            return new List<Missle> {
                new AirMissle("AirMissle", 90),
                new AirMissle("AirMissle", 90),
                new AirMissle("AirMissle", 90),
                new AirMissle("AirMissle", 90)
            };
        }
    }

    public class EagleFabric : PlainFabric
    {
        public override List<Bomb> CreateBombs()
        {
            return new List<Bomb>
            {
                new SimpleBomb("Sex Bomb", 500),
                new SimpleBomb("Sex Bomb", 500),
                new SimpleBomb("Sex Bomb", 500),
                new SimpleBomb("Sex Bomb", 500)
            };
        }

        public override List<Gun> CreateGuns()
        {
            return new List<Gun> { 
                new MiniGun("MiniGun", 20),
                new MiniGun("MiniGun", 20)
            };
        }

        public override List<Missle> CreateMissles()
        {
            return null;
        }
    }
}
