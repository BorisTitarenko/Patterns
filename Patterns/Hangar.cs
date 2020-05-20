using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Patterns
{
    public class Hangar
    {
        private static Hangar instance;
        public List<FightComponent> FightComponents { get; set; }

        /*private List<FightComponent> DeserializePlains() { 
            File.WriteAllText("")}*/
        private Hangar() {
            FightComponents = new List<FightComponent>();
        }

        public static Hangar GetInstance() {
            if (instance == null) {
                instance = new Hangar();
            }
            return instance;
        }

        public void AddDivision(Division division) {
            FightComponents.Add(division);
        }

        public void AddPlane(Division division, Plane plane) {
            new DivisionProxy((Division)FightComponents[FightComponents.IndexOf(division)])
                .AddFightComponent(plane);
        }

        public void RemovePlane(Division division, Plane plane) {
            new DivisionProxy((Division)FightComponents[FightComponents.IndexOf(division)])
               .RemoveFightComponent(plane);
        }

        public Division GetDivision(int index) {
            return (Division)FightComponents[index];
        }

        public void SendToWar(FightComponent fightComponent)
        {
            fightComponent.SendToWar();
        }

        public FightComponentMemento SaveFightComponent(FightComponent fc) {
            return new FightComponentMemento(fc);
        }

        public FightComponent RestoreFightComponent(FightComponentMemento fcm) {
            return fcm.FightComponent;
        }

    }
}
