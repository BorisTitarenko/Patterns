using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class FightComponentMemento
    {
        public FightComponent FightComponent { get; private set; }

        public FightComponentMemento(FightComponent fightComponent) {
            FightComponent = (FightComponent)fightComponent.Clone();
        }

    }
}
