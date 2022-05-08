using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Engines;


namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_LiscensePlate;
        private string m_ModelName;
        private Engine m_Engine;
        private float m_RemaindEnergyPrecantage;
        private List<Wheel> m_Wheels = new List<Wheel>();

        public string ModelName
        { 
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LiscensePlate
        {
            get { return m_LiscensePlate; }
            set { m_LiscensePlate = value; }
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

        public bool EqualsLicensePlates(string i_LicensePlate)
        { 
            return this.LiscensePlate == i_LicensePlate;
        }

        public override string ToString()
        {
            string combinedString = string.Join(" ", (object[])m_Wheels.ToArray());


            return String.Format(
@"Liscense Plate Number: {0}
Vehicle Model Name: {1}
{2} 
{3} ", m_LiscensePlate, m_ModelName, m_Engine, combinedString);
        }
    }
}
