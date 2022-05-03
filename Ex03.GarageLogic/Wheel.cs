using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaximalAirPressure;

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        public float MaximalAirPressure
        {
            get { return r_MaximalAirPressure; }
        }

        public void inflate(float i_Air)
        {
            if (i_Air < 0 || m_CurrentAirPressure + i_Air > r_MaximalAirPressure)
            {
                throw new ValueOutOfRanfeException();
            }
            m_CurrentAirPressure += i_Air;
        }
        //public void inflate()
        //{
        //    m_currentAirPressure = m_maximalAirPressure;
        //}
        public override string ToString()
        {
            return String.Format(
@"Wheels Manufacturer: {0}
Wheels Current Pressure: {1}
Wheels Maximal Pressure: {2}",
r_ManufacturerName, m_CurrentAirPressure, r_MaximalAirPressure);
        }
    }
}
