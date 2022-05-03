using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    class Car : Vehicle
    {
        private const byte k_NumOfWheels = 4;
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
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
            Red,
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
