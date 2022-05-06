using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private  string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximalAirPressure;

        public Wheel(float i_MaximalAirPressure)
        { 
            m_CurrentAirPressure = i_MaximalAirPressure;
            m_MaximalAirPressure = i_MaximalAirPressure;
        }
        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set 
            { 
                if ((value < 0)||(value > MaximalAirPressure))
                {
                    throw new ValueOutOfRangeException(0, MaximalAirPressure, "Wheel");
                }
                m_CurrentAirPressure = value; 
            }
        }
        public float MaximalAirPressure
        {
            get { return m_MaximalAirPressure; }
        }

        public void inflate(float i_Air)
        {
            if (i_Air < 0 || m_CurrentAirPressure + i_Air > m_MaximalAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaximalAirPressure, "Wheel");
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
@"
Wheel Manufacturer: {0}
Wheel Current Pressure: {1}
Wheel Maximal Pressure: {2}",
m_ManufacturerName, m_CurrentAirPressure, m_MaximalAirPressure);
        }
    }
}
