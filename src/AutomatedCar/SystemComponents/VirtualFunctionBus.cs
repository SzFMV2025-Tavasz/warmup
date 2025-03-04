namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.SystemComponents.Packets;
    using System.Collections.Generic;

    public class VirtualFunctionBus : GameBase
    {
        private List<SystemComponent> components = new List<SystemComponent>();

        private IReadOnlyDummyPacket DummyPacket;

        public void RegisterComponent(SystemComponent component)
        {
            this.components.Add(component);
        }

        public IReadOnlyDummyPacket getIReadOnlyDummyPacket()
        {
            return this.DummyPacket;
        }

        public void setIReadOnlyDummyPacket(IReadOnlyDummyPacket packet)
        {
          this.DummyPacket = packet;
        }

        protected override void Tick()
        {
            foreach (SystemComponent component in this.components)
            {
                component.Process();
            }
        }
    }
}