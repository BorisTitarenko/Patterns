using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public abstract class Strategy
    {
        public Plane Plane { get; set; }

        public Strategy(Plane plane) {
            Plane = plane;
        }

        public abstract void Attack();
    }


    public class BombsStrategy : Strategy {
        public BombsStrategy(Plane plane) : base(plane){ }

        public override void Attack()
        {
            foreach(Bomb bomb in Plane.Bombs) {
                bomb.ShowPower();
            }
        }
    }

    public class MisslesStrategy : Strategy
    {
        public MisslesStrategy(Plane plane) : base(plane) { }

        public override void Attack()
        {
            foreach (Missle missle in Plane.Missles)
            {
                missle.ShowPower();
            }
        }
    }


    public class Attacker {
        private Strategy attackStrategy;

        public Attacker(Strategy strategy) {
            attackStrategy = strategy;
        }

        public void Attac() {
            attackStrategy.Attack();
        }
    }

}
