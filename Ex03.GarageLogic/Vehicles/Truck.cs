using Ex03.GarageLogic.Engines;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private const byte k_NumOfWheels = 16;
        private const float k_MaximalWheelPressure = 24f;
        private const float k_MaximalFuelCapacity = 120f;

        private bool m_IsContainingRefrigiratedContent;
        private float m_CargoVolume;

        public bool IsContainingRefrigiratedContent
        {
            get { return m_IsContainingRefrigiratedContent; }
            set { m_IsContainingRefrigiratedContent = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public Truck()
        {
            base.Engine = new GasEngine(GasEngine.eFuelTypes.Soler, k_MaximalFuelCapacity);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(k_MaximalWheelPressure);
                base.Wheels.Add(newWheel);
            }
        }

        public override string ToString()
        {
            StringBuilder stringToPrint = new StringBuilder(base.ToString());
            stringToPrint.AppendFormat(
@"
Truck Details:
Containing Refrigirated Content: {0}
Cargo volume: {1}", IsContainingRefrigiratedContent.ToString(), CargoVolume);
            return stringToPrint.ToString();
        }
    }
}
