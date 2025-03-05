namespace AutomatedCar.SystemComponents.Sensors
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
        }
        DummyPacket dummyPacket;
        Circle circle = World.Instance.WorldObjects.FirstOrDefault(wo => wo is Circle) as Circle;
        AutomatedCar autoCar = World.Instance.ControlledCar;
        public override void Process()
        {
            dummyPacket.DistanceX = autoCar.X - circle.X;
            dummyPacket.DistanceY = autoCar.Y - circle.Y;
        }
    }
}
