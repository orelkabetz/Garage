﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Engine_Types
{
    public abstract class Engine
    {
        private float m_CurrentEnergy;
        private readonly float r_MaximalEnergy;
        public float CurrentEnergy
        { 
            get { return m_CurrentEnergy; } 
            set
            { 
                if (value < 0 | value > r_MaximalEnergy)
                {
                    throw new ValueOutOfRanfeException();
                }
                m_CurrentEnergy = value; 
            }
        }
        public float MaximalEnergy
        {
            get { return r_MaximalEnergy; }
        }
        public float EneregyPrecentage
        {
            get { return (m_CurrentEnergy / r_MaximalEnergy) * 100; }
        }
        public abstract void Fill(float i_EnergyToAdd);
    }
}