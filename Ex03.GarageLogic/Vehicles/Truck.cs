using Ex03.GarageLogic.Engine_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    class Truck : Vehicle
    {
        private const byte k_NumOfWheels = 16;
        private const float k_MaximalWheelPressure = 24f;
        private const float k_MaximalFuelCapacity = 120f;

        private bool m_IsContainingRefrigiratedContent;
        private readonly float r_CargoVolume;
        public bool IsContainingRefrigiratedContent
        {
            get { return m_IsContainingRefrigiratedContent; }
            set { m_IsContainingRefrigiratedContent = value; }
        }
        public float CargoVolume
        {
            get { return r_CargoVolume; }
        }
        public Truck(string i_WheelManufacturer)
        {
            base.Engine = new GasEngine();
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_WheelManufacturer, k_MaximalWheelPressure);
                base.Wheels.Add(newWheel);
            }
        }
    }
}
