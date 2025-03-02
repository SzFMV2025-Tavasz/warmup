using AutomatedCar.SystemComponents;
using AutomatedCar.SystemComponents.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCar.Models
{
    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        private DummyPacket dummyPacket;

        public override void Process()
        {
            var car = World.Instance.WorldObjects.First(worldObject => worldObject.GetType().Name == "AutomatedCar");
            var circle = World.Instance.WorldObjects.First(worldObject => worldObject.GetType().Name == "Circle");
            this.dummyPacket.DistanceX = car.X - circle.X;
            this.dummyPacket.DistanceY = car.Y - circle.Y;
        }
    }
}
