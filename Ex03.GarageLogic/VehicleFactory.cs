using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public enum eVehicleType
        {
            Motorcycle = 1,
            Car,
            Truck,
        }

        public enum eEngineType
        {
            Gas = 1,
            Electric,
        }

        public static Vehicle CreateNewVehicle(eVehicleType i_VehcileType, eEngineType i_EngineType)
        {
            Vehicle vehicle = null;
            if (i_VehcileType == eVehicleType.Motorcycle)
            {
                if (i_EngineType == eEngineType.Gas)
                {
                    //Motorcycle creation gas
                    vehicle = new Motorcycle(eEngineType.Gas);
                }
                else if (i_EngineType == eEngineType.Electric)
                {
                    //Motorcycle creation elec
                    vehicle = new Motorcycle(eEngineType.Electric);
                }
            }
            else if (i_VehcileType == eVehicleType.Car)
            {
                if (i_EngineType == eEngineType.Gas)
                {
                    // Car creation gas
                    vehicle = new Car(eEngineType.Gas);

                }
                else if (i_EngineType == eEngineType.Electric)
                {
                    //Car creation elec
                    vehicle = new Car(eEngineType.Electric);
                }
            }
            else if (i_VehcileType == eVehicleType.Truck)
            {
                // Truck creation gas
                vehicle = new Truck();
            }
            return vehicle;
        }
    }
}
