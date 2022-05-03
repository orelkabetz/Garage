using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    class Truck : Vehicle
    {
        private const byte k_NumOfWheels = 16;
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
    }
}
