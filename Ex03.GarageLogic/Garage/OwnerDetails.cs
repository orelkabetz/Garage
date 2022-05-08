using System;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class OwnerDetails
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleState m_VehicleState;

        public OwnerDetails(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = eVehicleState.Fixing;
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

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        public enum eVehicleState
        {
            Fixing = 1,
            Completed,
            Paid,
        }

        public override string ToString()
        {
            return String.Format(
@"Owner Name: {0}
Owner Phone Number: {1}
{2}
The Vehicle State: {3} ", m_OwnerName, m_OwnerPhoneNumber, m_Vehicle, m_VehicleState);
        }
    }
}
