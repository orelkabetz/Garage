using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    class Motorcycle : Vehicle
    {
        private const byte k_NumOfWheels = 2;
        private eLicenseType m_LicenseType;
        private readonly int r_EngineCapacity;
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
            A,
            A1,
            B1,
            BB,
        }
    }
}
