using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Engines
{
    public abstract class Engine
    {
        private float m_CurrentEnergy;
        private float m_MaximalEnergy;
        public float CurrentEnergy
        { 
            get { return m_CurrentEnergy; } 
            set
            { 
                if (value < 0 | value > m_MaximalEnergy)
                {
                    throw new ValueOutOfRangeException(0, m_MaximalEnergy, "Engine");
                }
                m_CurrentEnergy = value; 
            }
        }
        public float MaximalEnergy
        {
            get { return m_MaximalEnergy; }
            set { m_MaximalEnergy = value; }
        }
        public float EneregyPrecentage
        {
            get { return (m_CurrentEnergy / m_MaximalEnergy) * 100; }
        }
        public abstract void Fill(float i_EnergyToAdd);
    }
}
