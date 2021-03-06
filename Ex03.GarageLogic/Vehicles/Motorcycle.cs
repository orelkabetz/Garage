using System.Text;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        private const byte k_NumOfWheels = 2;
        private const float k_MaximalWheelPressure = 31f;
        private const float k_MaximalFuelCapacity = 6.2f;
        private const float k_MaximalBatteryCapacity = 2.5f;

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(VehicleFactory.eEngineType i_Type)
        {
            if (i_Type == VehicleFactory.eEngineType.Gas)
            {
                base.Engine = new GasEngine(GasEngine.eFuelTypes.Octan98, k_MaximalFuelCapacity);
            }
            else if(i_Type == VehicleFactory.eEngineType.Electric)
            {
                this.Engine = new ElectricEngine(k_MaximalBatteryCapacity);
            }
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(k_MaximalWheelPressure);
                base.Wheels.Add(newWheel);
            }
        }

        public int EngineCapacity
        { 
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override string ToString()
        {
            StringBuilder stringToPrint = new StringBuilder(base.ToString());
            stringToPrint.AppendFormat(
@"
Motorcycle Details:
License type: {0}
Engine capacity: {1}", LicenseType, EngineCapacity);
            return stringToPrint.ToString();
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            BB,
        }
    }
}
