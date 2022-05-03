using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Engine_Types
{
    class Electric : Engine
    {
        public float RemainingBatteryTime
        {
            get { return base.CurrentEnergy; }
            set { base.CurrentEnergy = value; }
        }
        public float MaximalBatteryTime
        {
            get { return base.MaximalEnergy; }
        }
        public override string ToString()
        {
            return String.Format(
@"Engine Remaining Battery Time: {0}
Engine Maximal Battery Time: {1}
Which is {2}%",
RemainingBatteryTime ,MaximalBatteryTime, base.EneregyPrecentage);
        }

        public override void Fill(float i_EnergyTimeToAdd)
        {
            charge(i_EnergyTimeToAdd);
        }

        private void charge(float i_BatteryTimeToAdd)
        {
            if (i_BatteryTimeToAdd < 0 || i_BatteryTimeToAdd + RemainingBatteryTime > MaximalBatteryTime)
            {
                throw new ValueOutOfRanfeException();
            }
            RemainingBatteryTime += i_BatteryTimeToAdd;
        }
    }
}
