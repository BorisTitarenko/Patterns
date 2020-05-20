using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Division : FightComponent
    {
        public List<FightComponent> Plains { get; set; }
        public String Name { get; private set; }

        public Division(String name)
        {
            this.Name = name;
            context = new Context(new HangarDivisionState());
            Plains = new List<FightComponent>();
        }

        public override void AddFightComponent(FightComponent component)
        {
            Plains.Add(component);
        }

        public override void RemoveFightComponent(FightComponent component)
        {
            Plains.Remove(component);
        }

        public override FightComponent SendToWar()
        {
            Console.WriteLine(context.Request());
            Console.WriteLine(context.Request());
            return this;
        }

        public override FightComponent GetFightComponent(int index)
        {
            return Plains[index];
        }

        public override object Clone()
        {
            Division div = new Division(this.Name);
            foreach(Plane plain in this.Plains){
                div.AddFightComponent((Plane)plain.Clone());
            }
            return div;

        }
    }
}
