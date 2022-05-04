using Ex03.GarageLogic.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static Vehicle CreateNewVehicle(eVehicleType vehcileType, eEngineType engineType)
        {
            Vehicle vehicle = null;
            if (vehcileType == eVehicleType.Motorcycle)
            {
                if (engineType == eEngineType.Gas)
                {
                    //Motorcycle creation gas
                    vehicle = new Motorcycle(eEngineType.Gas);
                }
                else if (engineType == eEngineType.Electric)
                {
                    //Motorcycle creation elec
                    vehicle = new Motorcycle(eEngineType.Electric);
                }
            }
            else if (vehcileType == eVehicleType.Car)
            {
                if (engineType == eEngineType.Gas)
                {
                    // Car creation gas
                    vehicle = new Car(eEngineType.Gas);

                }
                else if (engineType == eEngineType.Electric)
                {
                    //Car creation elec
                    vehicle = new Car(eEngineType.Electric);
                }
            }
            else if (vehcileType == eVehicleType.Truck)
            {
                // Truck creation gas
                vehicle = new Truck();
            }
            return vehicle;
        }
    }
}
