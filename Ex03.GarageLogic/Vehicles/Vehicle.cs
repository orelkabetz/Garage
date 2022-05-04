using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Engine_Types;


namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LiscensePlate;
        private Engine m_Engine;
        private float m_RemaindEnergyPrecantage;
        private List<Wheel> m_Wheels;

        //public Vehicle(string i_ModelName, string i_LiscensePlate)
        //{

        //}
        public string ModelName
        { 
            get { return r_ModelName; } 
        }
        public string LiscensePlate
        {
            get { return r_LiscensePlate; }
        }
        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
        public float RemaindEnergyPrecantage
        {
            get { return m_RemaindEnergyPrecantage; }
            set { m_RemaindEnergyPrecantage = value; }
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

    }
}
