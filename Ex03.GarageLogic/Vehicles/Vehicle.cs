using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Engines;


namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string r_ModelName;
        private string r_LiscensePlate;
        private Engine m_Engine;
        private float m_RemaindEnergyPrecantage;
        private List<Wheel> m_Wheels = new List<Wheel>();

        //public Vehicle(string i_ModelName, string i_LiscensePlate)
        //{

        //}
        public string ModelName
        { 
            get { return r_ModelName; } 
            set { r_ModelName = value; }
        }
        public string LiscensePlate
        {
            get { return r_LiscensePlate; }
            set { r_LiscensePlate = value; }
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
