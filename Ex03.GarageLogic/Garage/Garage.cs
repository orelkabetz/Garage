using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    class Garage
    {
        private readonly Dictionary<string, OwnerDetails> m_GarageVehicles;

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, OwnerDetails>();
        }

        //public void addVehicle(string i_LicensePlate)
        //{
        //    if (m_GarageVehicles.ContainsKey(i_LicensePlate))
        //    {

        //    }
        //    else
        //    {
                
        //    }
        //}
    }
}
