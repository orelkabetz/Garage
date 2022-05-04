using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Engine_Types;

namespace Ex03.GarageLogic.Vehicles
{
    class Car : Vehicle
    {
        private const byte k_NumOfWheels = 4;
        private const float k_MaximalWheelPressure = 29f;
        private const float k_MaximalFuelCapacity = 38f;
        private const float k_MaximalBatteryCapacity = 3.3f;

        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
       

        public Car(VehicleFactory.eEngineType type)
        {
            if (type == VehicleFactory.eEngineType.Gas)
            {
                base.Engine = new GasEngine(k_MaximalFuelCapacity);
            }
            else if (type == VehicleFactory.eEngineType.Electric)
            {
                this.Engine = new ElectricEngine(k_MaximalBatteryCapacity);
            }
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(k_MaximalWheelPressure);
                base.Wheels.Add(newWheel);
            }
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }
        public enum eColor
        {
            Red = 1,
            White,
            Green,
            Blue,
        }
        public enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }
    }
}
