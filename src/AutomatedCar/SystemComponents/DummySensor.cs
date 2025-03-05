namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DummySensor : SystemComponent
    {
        private AutomatedCar automatedCar { get; set; }
        private Circle circle { get; set; }
        private DummyPacket dummyPacket { get; set; }
        public DummySensor(VirtualFunctionBus virtualFunctionBus, AutomatedCar automatedCar) : base(virtualFunctionBus)
        {
            this.circle = World.Instance.WorldObjects.FindAll(x => (x as Circle) != null).FirstOrDefault() as Circle;
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
            this.automatedCar = automatedCar;
        }

        public override void Process()
        {
            int distanceXDiff = Math.Abs(this.circle.X - automatedCar.X);
            int distanceYDiff = Math.Abs(this.circle.Y - automatedCar.Y);

            dummyPacket.DistanceX = distanceXDiff;
            dummyPacket.DistanceY = distanceYDiff;
        }
    }
}
