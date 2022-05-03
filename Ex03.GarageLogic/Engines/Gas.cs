using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Engine_Types
{
    class Gas : Engine
    {
        private eFuelTypes m_FuelType;
        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
        public float RemainingFuel
        {
            get { return base.CurrentEnergy; }
            set { base.CurrentEnergy = value; }
        }
        public float MaximalBatteryTime
        {
            get { return base.MaximalEnergy; }
        }
        public enum eFuelTypes
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
        public override string ToString()
        {
            return String.Format(
@"Engine Remaining Fuel: {0} Liters
Engine Maximal Fuel: {1} Liters
Which is {2}%", MaximalBatteryTime, base.EneregyPrecentage);
        }
        public override void Fill(float i_EnergyToToAdd)
        {
            fuel(i_EnergyToToAdd);
        }
        private void fuel(float i_FuelToToAdd)
        {
            if (i_FuelToToAdd < 0 || i_FuelToToAdd + RemainingFuel > MaximalEnergy)
            {
                throw new ValueOutOfRanfeException();
            }
            RemainingFuel += i_FuelToToAdd;
        }
    }
}
