using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    class DivisionProxy : FightComponent
    {
        public Division Division { get; set; }
        public DivisionProxy(Division division) {
            Division = division;
        }

        public override void AddFightComponent(FightComponent component)
        {
            if (Division.Plains.Count < 10) {
                Division.AddFightComponent(component);
            }
        }

        public override void RemoveFightComponent(FightComponent component)
        {
            if (Division.Plains.Count > 1) {
                Division.RemoveFightComponent(component);
            }
        }

        public override FightComponent SendToWar()
        {
            return Division.SendToWar();
        }

        public override FightComponent GetFightComponent(int index)
        {
            return Division.Plains[index];
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
