using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Division fc = new Division("Joy Division");
            fc.AddFightComponent(new HornetFabric().CreatePlain("Plain 1"));
            fc.AddFightComponent(new HornetFabric().CreatePlain("Plain 2"));
            fc.AddFightComponent(new EagleFabric().CreatePlain("Plain 3"));

            Hangar.GetInstance().AddDivision(fc);
            Plane plane = new EagleFabric().CreatePlain("Plain 1");

            fc.AddFightComponent(plane);
            Hangar.GetInstance().AddDivision(fc);
            Hangar.GetInstance().RemovePlane(fc, plane);
            Hangar.GetInstance().SendToWar(fc);

            FightComponentMemento fcm = Hangar.GetInstance().SaveFightComponent(plane);
            Hangar.GetInstance().SendToWar(plane);
            Console.WriteLine(plane.GetStateStatus());
            plane = (Plane)Hangar.GetInstance().RestoreFightComponent(fcm);
            Console.WriteLine(plane.GetStateStatus());


            String s = "Mykulyak chmo";
            SerDes.serialize(s);
            s = (String) SerDes.deserialize();
            Console.WriteLine(s);


            Plane plane1 = new HornetFabric().CreatePlain("M");
            Plane plane2 = new EagleFabric().CreatePlain("B");

            Attacker attacker = new Attacker(new MisslesStrategy(plane1));
            attacker.Attac();
            attacker = new Attacker(new BombsStrategy(plane2));
            attacker.Attac();

            RadioStation radioStation = new RadioStation(new List<float> { (float)120.3, (float)100.9, (float)100.4 });
            Iterator iterator = radioStation.CreateIterator();
            float item = iterator.First();
            while (!iterator.IsDone())
            {
                Console.WriteLine(item);
                item = iterator.Next();
            }
        }
    }
}
