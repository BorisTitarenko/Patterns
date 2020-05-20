using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public abstract class FightComponent : ICloneable
    {
        protected Context context;
        public abstract void AddFightComponent(FightComponent component);
        public abstract void RemoveFightComponent(FightComponent component);
        public abstract FightComponent GetFightComponent(int index);
        public abstract FightComponent SendToWar();
        public abstract object Clone();
    }
}
