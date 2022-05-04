using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Engine_Types;

namespace Ex03.GarageLogic.Vehicles
{
    class Motorcycle : Vehicle
    {
        private const byte k_NumOfWheels = 2;
        private const float k_MaximalWheelPressure = 31f;
        private const float k_MaximalFuelCapacity = 6.2f;
        private const float k_MaximalBatteryCapacity = 2.5f;

        private eLicenseType m_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(VehicleFactory.eEngineType type)
        {
            if (type == VehicleFactory.eEngineType.Gas)
            {
                base.Engine = new GasEngine(k_MaximalFuelCapacity);
            }
            else if(type == VehicleFactory.eEngineType.Electric)
            {
                this.Engine = new ElectricEngine(k_MaximalBatteryCapacity);
            }
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(k_MaximalWheelPressure);
                base.Wheels.Add(newWheel);
            }

        }

        public int EngineCapacity
        { 
            get { return r_EngineCapacity; } 
        }
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            BB,
        }
    }
}
