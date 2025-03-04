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
        private VirtualFunctionBus vfb { get; set; }
        private AutomatedCar automatedCar { get; set; }
        public DummySensor(VirtualFunctionBus virtualFunctionBus, AutomatedCar automatedCar) : base(virtualFunctionBus)
        {
            this.vfb = virtualFunctionBus;
            this.automatedCar = automatedCar;
        }

        public override void Process()
        {
            var circles = World.Instance.WorldObjects.FindAll(x => (x as Circle) != null);
            Circle circle = circles.FirstOrDefault() as Circle;


            int distanceXDiff = Math.Abs(circle.X - automatedCar.X);
            int distanceYDiff = Math.Abs(circle.Y - automatedCar.Y);

            vfb.setIReadOnlyDummyPacket(new DummyPacket()
            {
                DistanceX = distanceXDiff,
                DistanceY = distanceYDiff
            });

        }
    }
}
