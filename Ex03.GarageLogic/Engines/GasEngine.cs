using System;

namespace Ex03.GarageLogic.Engines
{
    public class GasEngine : Engine
    {
        private eFuelTypes m_FuelType;

        public GasEngine(eFuelTypes i_FuelType, float i_MaximalFuelCapacity)
        {
            base.MaximalEnergy = i_MaximalFuelCapacity;
            m_FuelType = i_FuelType;
        }

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

        public float MaximalFuel
        {
            get { return base.MaximalEnergy; }
        }

        public enum eFuelTypes
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98,
        }

        public override string ToString()
        {
            return String.Format(
@"Engine Remaining Fuel: {0} Liters
Engine Maximal Fuel: {1} Liters
Which is {2}%",RemainingFuel, MaximalFuel, base.EneregyPrecentage);
        }

        public override void Fill(float i_EnergyToToAdd)
        {
            fuel(i_EnergyToToAdd);
        }

        private void fuel(float i_FuelToToAdd)
        {
            if (i_FuelToToAdd < 0 || i_FuelToToAdd + RemainingFuel > MaximalEnergy)
            {
                throw new ValueOutOfRangeException(0, MaximalEnergy, "Gas Engine");
            }
            RemainingFuel += i_FuelToToAdd;
        }
    }
}
