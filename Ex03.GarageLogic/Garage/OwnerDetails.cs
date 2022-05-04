using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class OwnerDetails
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private List<Vehicle> m_Vehicles;
        private eVehicleState m_CarState;
        public OwnerDetails(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            List<Vehicle> m_Vehicles = new List<Vehicle>();
            m_CarState = eVehicleState.Fixing;
        }
        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }
        public List<Vehicle> Vehicles
        {
            get { return m_Vehicles; }
            set { m_Vehicles = value; }
        }
        public eVehicleState CarState
        {
            get { return m_CarState; }
            set { m_CarState = value; }
        }
        public enum eVehicleState
        {
            Fixing,
            Completed,
            Paid,
        }

    }
}
