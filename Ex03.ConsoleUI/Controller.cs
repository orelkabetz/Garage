using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.Garage;

namespace Ex03.ConsoleUI
{
    public static class Controller
    {
        private static Garage m_Garage;

        public static void Run()
        {
            eUserOpstions userChoice;
            m_Garage = new Garage();
            Messages.Hello();
            try
            {
                do
                {
                    Console.Clear();
                    Messages.DisplayMenu();

                    userChoice = getUserChoice();
                    operateUserCohice(ref userChoice);
                }
                while (userChoice != eUserOpstions.Esc);
                Messages.ByeBye();
            }
            catch (FormatException exception)
            {
                Messages.FormatException(exception);
            }
        }

        private static eUserOpstions getUserChoice()
        {
            uint userChoice;
            if (!UInt32.TryParse(Console.ReadLine(), out userChoice))
            {
                throw new FormatException("Invalid menu option choice");
            }
            return (eUserOpstions)userChoice;
        }

        private static void operateUserCohice(ref eUserOpstions userChoice)
        {
            try
            {
                switch (userChoice)
                {
                    case eUserOpstions.AddVehicle:
                        addVehicle();
                        break;
                    case eUserOpstions.DisplayLicensePlates:
                        displayLicensePlates();
                        break;
                    case eUserOpstions.SetState:
                        setState();
                        break;
                    case eUserOpstions.InflateToMax:
                        inflateToMax();
                        break;
                    case eUserOpstions.FuelVehicle:
                        fuelVehicle();
                        break;
                    case eUserOpstions.ChargeVehicle:
                        chargeVehicle();
                        break;
                    case eUserOpstions.DisplayDetails:
                        disaplyDetails();
                        break;
                    case eUserOpstions.Esc:
                        Messages.ByeBye();
                        return;
                        default:
                        Messages.InvalidChoice();
                        break;
                }
            }
         
            catch (FormatException exception)
            {
                Messages.FormatException(exception);
            }
            catch (ArgumentException exception)
            {
                Messages.ArgumentException(exception);

            }
            catch (ValueOutOfRangeException exception) 
            {
                Messages.ValueOutOfRangeException(exception);
            }
            finally
            {
                if (userChoice != eUserOpstions.Esc)
                {
                    Messages.DisplayMenu();
                    try
                    {
                        userChoice = getUserChoice();
                    }
                    catch (FormatException exception)
                    {
                        Messages.FormatException(exception);
                    }
                    operateUserCohice(ref userChoice);
                }
                Messages.PressAnyKey();
            }
        }

        private static void disaplyDetails()
        {
            Messages.LicensePlateNumber();
            string licensePlate = Console.ReadLine();
            if (!m_Garage.GarageVehicles.ContainsKey(licensePlate))
            {
                throw new ArgumentNullException("The license plate you asked for is not in our garage");
            }
            Console.Clear();
            Console.WriteLine(m_Garage.GarageVehicles[licensePlate].ToString());
            Messages.PressAnyKey();
        }

        private static void chargeVehicle()
        {
           
                Messages.LicensePlateNumber();
                string licensePlate = Console.ReadLine();
                Messages.ChargeAmount();
                string stringChargeAmount = Console.ReadLine();
                float chargeAmount;
                if(!float.TryParse(stringChargeAmount, out chargeAmount))
                {
                    throw new FormatException("You have to insert Real Integer for amount of chrging");

                }
                if (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine is GasEngine)
                {
                    throw new ArgumentException("The vehicle you asked to fuel has gas engine");
                }
            if ((chargeAmount > 0) && (chargeAmount <= (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as ElectricEngine).MaximalBatteryTime))
            {
                m_Garage.GarageVehicles[licensePlate].Vehicle.Engine.Fill(chargeAmount);
            }
            else
            {
                throw new ValueOutOfRangeException(0,(m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as ElectricEngine).MaximalBatteryTime, "Electric Engine");
            }
            Messages.PressAnyKey();

        }

        private static void fuelVehicle()
        {
                Messages.LicensePlateNumber();
                string licensePlate = Console.ReadLine();
                Messages.FuelType();
                string stringFuelType = Console.ReadLine();
                GasEngine.eFuelTypes eFuelType;
                if (!Enum.TryParse(stringFuelType, out eFuelType)) {
                    throw new FormatException("No matching fuel type , pls enter number according the menu");
                }
                if (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine is GasEngine)
                {
                    if (eFuelType != (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as GasEngine).FuelType)
                    {
                        throw new ArgumentException("The fuel type you asked is not matching the vehicle's fuel type");
                    }
                }
                else // Engine is Electric
                {
                    throw new ArgumentException("The vehicle you asked to fuel has electric engine");
                }

                Messages.FuelAmount();
                string stringFuelAmount = Console.ReadLine();
                float fuelAmount;
                if(!float.TryParse(stringFuelAmount, out fuelAmount))
                {
                    throw new FormatException("No matching fuel amount , pls enter real integer");

                };
                if ((fuelAmount > 0) && (fuelAmount <= (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as GasEngine).MaximalFuel))
                {
                    m_Garage.GarageVehicles[licensePlate].Vehicle.Engine.Fill(fuelAmount);
                }else{
                throw new ValueOutOfRangeException(0, (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as GasEngine).MaximalFuel,"Gas Engine");
                }
            Messages.PressAnyKey();

        }

        private static void inflateToMax()
        {
            Messages.LicensePlateNumber();
            string licensePlate = Console.ReadLine();
            foreach (Wheel wheel in m_Garage.GarageVehicles[licensePlate].Vehicle.Wheels)
            {
                wheel.inflate(wheel.MaximalAirPressure);
            }
            Messages.PressAnyKey();
        }

        private static void setState()
        {
            Messages.LicensePlateNumber();
            string licensePlate = Console.ReadLine();
            Messages.SetVehicleState();
            string stringVehicleState = Console.ReadLine();
            OwnerDetails.eVehicleState eVehicleState;
            if(!Enum.TryParse(stringVehicleState, out eVehicleState))
            {
                throw new FormatException("Invalid state , pls eneter right number according to menu");
            }
            m_Garage.GarageVehicles[licensePlate].VehicleState = eVehicleState;
            Messages.PressAnyKey();
        }

        private static void displayLicensePlates()
        {
            Messages.DisplayLicensePlatesMenu();
            string userChoice = Console.ReadLine();
            OwnerDetails.eVehicleState e_UserStateChoice;
            if(!Enum.TryParse(userChoice, out e_UserStateChoice))
            {
                throw new FormatException("invalid input of user choice, please insert right number according to menu");
            }
            
            switch (e_UserStateChoice)
            {
                case OwnerDetails.eVehicleState.Fixing:
                    displayVehiclesInFixing();
                    break;
                case OwnerDetails.eVehicleState.Completed:
                    displayCompletedVehicles();
                    break;
                case OwnerDetails.eVehicleState.Paid:
                    displayPaidVehicles();
                    break;
                default:
                    displayAllVehicles();
                    break;
            }
            Messages.PressAnyKey();
        }

        private static void displayAllVehicles()
        {
            Console.Clear();

            foreach (KeyValuePair<string, OwnerDetails> vehicle in m_Garage.GarageVehicles)
            {
                Console.WriteLine(vehicle.Key);
            }
        }

        private static void displayPaidVehicles()
        {
            Console.Clear();

            foreach (KeyValuePair<string, OwnerDetails> vehicle in m_Garage.GarageVehicles)
            {
                if (vehicle.Value.VehicleState == OwnerDetails.eVehicleState.Paid)
                {
                    Console.WriteLine(vehicle.Key);
                }
            }
        }

        private static void displayCompletedVehicles()
        {
            Console.Clear();

            foreach (KeyValuePair<string, OwnerDetails> vehicle in m_Garage.GarageVehicles)
            {
                if (vehicle.Value.VehicleState == OwnerDetails.eVehicleState.Completed)
                {
                    Console.WriteLine(vehicle.Key);
                }
            }
        }

        private static void displayVehiclesInFixing()
        {
            Console.Clear();
            foreach (KeyValuePair<string, OwnerDetails> vehicle in m_Garage.GarageVehicles)
            {
                if (vehicle.Value.VehicleState == OwnerDetails.eVehicleState.Fixing)
                {
                    Console.WriteLine(vehicle.Key);
                }
            }
        }

        private static void addVehicle()
        {
            OwnerDetails owner;
            Vehicle vehicle;

            Messages.LicensePlateNumber();
            string licensePlate = Console.ReadLine();
            if (checkIfLicensePlateAlreadyExists(licensePlate))
            {
                m_Garage.GarageVehicles[licensePlate].VehicleState = OwnerDetails.eVehicleState.Fixing;
                Messages.VehicleExists();
            }
            else // Doesn't exisxts and we want to create new vehicle
            {
                VehicleFactory.eVehicleType vehcileType;
                VehicleFactory.eEngineType engineType;
                getVehcileType(out vehcileType, out engineType);
                vehicle = VehicleFactory.CreateNewVehicle(vehcileType, engineType);
                vehicle.LiscensePlate = licensePlate;
                detailsRequest(vehicle, vehcileType, engineType, out owner);
                m_Garage.GarageVehicles.Add(vehicle.LiscensePlate, owner);
                Messages.SuccsefullVehicleAdding();
                Messages.PressAnyKey();
            }
        }

        private static bool checkIfLicensePlateAlreadyExists(string i_LicensePlate)
        {
            if (m_Garage.GarageVehicles.ContainsKey(i_LicensePlate))
            {
                return true;
            }
            return false;
        }

        private static void detailsRequest(Vehicle io_Vehicle, VehicleFactory.eVehicleType i_VehcileType, VehicleFactory.eEngineType i_EngineType, out OwnerDetails io_Owner)
        {
            Messages.ModelName();
            io_Vehicle.ModelName = Console.ReadLine();

            io_Owner = ownerDetailsRequest();

            if (i_EngineType == VehicleFactory.eEngineType.Gas)
            {
                Messages.LeftGas();
                float leftGas;
                if(!float.TryParse(Console.ReadLine(), out leftGas))
                {
                    throw new FormatException("invalid input of left gas , please insert real Integer");
                }
                io_Vehicle.Engine.CurrentEnergy = leftGas;
            }
            else // Electric
            {
                Messages.LeftBattery();
                float LeftBattery;
                if(!float.TryParse(Console.ReadLine(), out LeftBattery))
                {
                    throw new FormatException("invalid input of left Battery , please insert real Integer");

                }
                io_Vehicle.Engine.CurrentEnergy = LeftBattery;

            }

            if (i_VehcileType == VehicleFactory.eVehicleType.Motorcycle)
            {
                Messages.MotorcycleLicenseType();
                Motorcycle.eLicenseType licenseType;
                if(!Enum.TryParse(Console.ReadLine(), out licenseType))
                {
                    throw new FormatException("invalid input of license Type , please insert right number according to menu");

                }
                (io_Vehicle as Motorcycle).LicenseType = licenseType;

                Messages.EngineVolume();
                uint engineVolume;
                if(UInt32.TryParse(Console.ReadLine(), out engineVolume))
                {
                    throw new FormatException("invalid input of engine volume , please enter Integer");
                }
                (io_Vehicle as Motorcycle).EngineCapacity = (int)engineVolume;

            }
            else if (i_VehcileType == VehicleFactory.eVehicleType.Car)
            {
                Messages.CarColor();
                Car.eColor color;
                if (!Enum.TryParse(Console.ReadLine(), out color)){
                    throw new FormatException("invalid input of color Type , please insert right number according to menu");
                }
                (io_Vehicle as Car).Color = color;

                Messages.CarNumOfDoors();
                Car.eNumOfDoors doors;
                if(!Enum.TryParse(Console.ReadLine(), out doors))
                {
                    throw new FormatException("invalid input of doors amount , please insert right number according to menu");
                }
                (io_Vehicle as Car).NumOfDoors = doors;
            }
            else // Truck
            {
                Messages.TruckRefrigirated();
                string refrigirated = Console.ReadLine();
                if (refrigirated == "1")
                {
                    (io_Vehicle as Truck).IsContainingRefrigiratedContent = true;
                }
                else if(refrigirated == "2")
                {
                    (io_Vehicle as Truck).IsContainingRefrigiratedContent = false;
                }
                else
                {
                    throw new FormatException("invalid input of refrigirated content, please insert right number according to menu");
                }


                Messages.TruckCargoVolume();
                float cargoVolume;
                if(!float.TryParse(Console.ReadLine(), out cargoVolume))
                {
                    throw new FormatException("invalid input of cargo Volume , please insert positive real number");
                }
                if(cargoVolume < 0)
                {
                    throw new FormatException("invalid input of cargo Volume , please insert positive real number");

                }
                (io_Vehicle as Truck).CargoVolume = cargoVolume;

            }

            Messages.WheelManufacturer();
            string manufacturerName = Console.ReadLine();
            foreach (Wheel wheel in io_Vehicle.Wheels)
            {
                wheel.ManufacturerName = manufacturerName;
            }


            Messages.CurrentWheelPressure();
            float wheelPressure;
            if(!float.TryParse(Console.ReadLine(), out wheelPressure))
            {
                throw new FormatException("invalid input of wheel pressure , please insert positive real number");
            }
            if(wheelPressure < 0)
            {
                throw new FormatException("invalid input of wheel pressure , please insert positive real number");
            }
            foreach (Wheel wheel in io_Vehicle.Wheels)
            {
                wheel.CurrentAirPressure = wheelPressure;
            }

            io_Owner.Vehicle = io_Vehicle;
        }

        private static OwnerDetails ownerDetailsRequest()
        {
            
            Messages.OwnerName();
            string ownerName = Console.ReadLine();

            Messages.OwnerPhoneNumber();
            string ownerPhoneNumber = Console.ReadLine();

            if (m_Garage.Owners.Count != 0)
            {
                foreach (OwnerDetails owner in m_Garage.Owners)
                {
                    if ((owner.OwnerName == ownerName) && (owner.OwnerPhoneNumber == ownerPhoneNumber))
                    {
                        return owner;
                    }
                }
            }

            return new OwnerDetails(ownerName, ownerPhoneNumber);
        }

        private static void getVehcileType(out VehicleFactory.eVehicleType vehcileType, out VehicleFactory.eEngineType engineType)
        {
            uint vehcileTypeInt, engineTypeInt;
            Messages.DisplayVehicleTypes();
            if(!UInt32.TryParse(Console.ReadLine(), out vehcileTypeInt))
            {
                throw new FormatException("Have to enter right number for vehicle");
            } // Exception or if/else
            vehcileType = (VehicleFactory.eVehicleType)vehcileTypeInt;
            if (vehcileType != VehicleFactory.eVehicleType.Truck)
            {
                Messages.DisplayEngineTypes();
                if(!UInt32.TryParse(Console.ReadLine(), out engineTypeInt)){
                    throw new FormatException("Have to enter right number for engine type");
                } // Exception or if/else
                engineType = (VehicleFactory.eEngineType)engineTypeInt;
            }
            else // Truck
            {
                engineType = VehicleFactory.eEngineType.Gas;
            }
        }

        public enum eUserOpstions
        {
            AddVehicle = 1,
            DisplayLicensePlates,
            SetState,
            InflateToMax,
            FuelVehicle,
            ChargeVehicle,
            DisplayDetails,
            Esc,
        }
    }
}
