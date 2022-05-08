using System.Collections.Generic;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private Dictionary<string, OwnerDetails> m_GarageVehicles; // String is for the License Plate number
        private List<OwnerDetails> m_Owners;

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, OwnerDetails>();
            m_Owners = new List<OwnerDetails>();
        }

        public Dictionary<string, OwnerDetails> GarageVehicles
        { 
            get { return m_GarageVehicles; } 
            set { m_GarageVehicles = value; }
        }

        public List<OwnerDetails> Owners
        {
            get { return m_Owners; }
            set { m_Owners = value; }
        }
    }
}
