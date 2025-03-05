namespace AutomatedCar.SystemComponents
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
        
        private AutomatedCar car;
        private Circle circle;
        private DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus, AutomatedCar car) : base(virtualFunctionBus)
        {
            this.car = car;
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }
        

        public override void Process()
        {
            circle = World.Instance.WorldObjects.OfType<Circle>().FirstOrDefault();
            if (circle != null)
            {
                dummyPacket.DistanceX = car.X - circle.X;
                dummyPacket.DistanceY = car.Y - circle.Y;
            }
        }
    }
}
