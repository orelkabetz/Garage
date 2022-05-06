using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.Garage;
using Ex03;

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
            do
            {
                Console.Clear();
                Messages.DisplayMenu();
                userChoice = getUserChoice();
                operateUserCohice(ref userChoice);
            } while (userChoice != eUserOpstions.Esc);
            Messages.ByeBye();
        }

        private static eUserOpstions getUserChoice()
        {
            int userChoice;
            Int32.TryParse(Console.ReadLine(), out userChoice);
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
            catch (ValueOutOfRangeException exception) // לטפל
            {
                Messages.ValueOutOfRangeException(exception);
            }
            finally
            {
                if (userChoice != eUserOpstions.Esc)
                {
                    Messages.DisplayMenu();
                    userChoice = getUserChoice();
                    operateUserCohice(ref userChoice);
                }
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
            try
            {
                Messages.LicensePlateNumber();
                string licensePlate = Console.ReadLine();
                Messages.ChargeAmount();
                string stringChargeAmount = Console.ReadLine();
                float chargeAmount;
                float.TryParse(stringChargeAmount, out chargeAmount);
                if (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine is GasEngine)
                {
                    throw new ArgumentException("The vehicle you asked to fuel has gas engine");
                }
                if ((chargeAmount > 0) && (chargeAmount <= (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as ElectricEngine).MaximalBatteryTime))
                {
                    m_Garage.GarageVehicles[licensePlate].Vehicle.Engine.Fill(chargeAmount);
                }
            }
            catch (Exception) // Handle later
            {

            }
            Messages.PressAnyKey();
        }

        private static void fuelVehicle()
        {
            try
            {
                Messages.LicensePlateNumber();
                string licensePlate = Console.ReadLine();
                Messages.FuelType();
                string stringFuelType = Console.ReadLine();
                GasEngine.eFuelTypes eFuelType;
                Enum.TryParse(stringFuelType, out eFuelType);
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
                float.TryParse(stringFuelAmount, out fuelAmount);
                if ((fuelAmount > 0) && (fuelAmount <= (m_Garage.GarageVehicles[licensePlate].Vehicle.Engine as GasEngine).MaximalFuel))
                {
                    m_Garage.GarageVehicles[licensePlate].Vehicle.Engine.Fill(fuelAmount);
                }
            }
            catch (Exception) // Handle later
            {

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
            Enum.TryParse(stringVehicleState, out eVehicleState);
            m_Garage.GarageVehicles[licensePlate].VehicleState = eVehicleState;
            Messages.PressAnyKey();
        }

        private static void displayLicensePlates()
        {
            Messages.DisplayLicensePlatesMenu();
            string userChoice = Console.ReadLine();
            OwnerDetails.eVehicleState e_UserStateChoice;
            Enum.TryParse(userChoice, out e_UserStateChoice);
            
            switch (e_UserStateChoice)
            {
                case OwnerDetails.eVehicleState.Fixing:
                    DisplayVehiclesInFixing();
                    break;
                case OwnerDetails.eVehicleState.Completed:
                    DisplayCompletedVehicles();
                    break;
                case OwnerDetails.eVehicleState.Paid:
                    DisplayPaidVehicles();
                    break;
                default:
                    DisplayAllVehicles();
                    break;
            }
            Messages.PressAnyKey();
        }

        private static void DisplayAllVehicles()
        {
            Console.Clear();

            foreach (KeyValuePair<string, OwnerDetails> vehicle in m_Garage.GarageVehicles)
            {
                Console.WriteLine(vehicle.Key);
            }
        }

        private static void DisplayPaidVehicles()
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

        private static void DisplayCompletedVehicles()
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

        private static void DisplayVehiclesInFixing()
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
            }
            else // Doesn't exisxts and we want to create new vehicle
            {
                VehicleFactory.eVehicleType vehcileType;
                VehicleFactory.eEngineType engineType;
                GetVehcileType(out vehcileType, out engineType);
                vehicle = VehicleFactory.CreateNewVehicle(vehcileType, engineType);
                vehicle.LiscensePlate = licensePlate;
                DetailsRequest(vehicle, vehcileType, engineType, out owner);
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

        private static void DetailsRequest(Vehicle io_Vehicle, VehicleFactory.eVehicleType i_VehcileType, VehicleFactory.eEngineType i_EngineType, out OwnerDetails io_Owner)
        {
            Messages.ModelName();
            io_Vehicle.ModelName = Console.ReadLine();

            io_Owner = OwnerDetailsRequest();

            if (i_EngineType == VehicleFactory.eEngineType.Gas)
            {
                Messages.LeftGas();
                float leftGas;
                float.TryParse(Console.ReadLine(), out leftGas);
                io_Vehicle.Engine.CurrentEnergy = leftGas;
            }
            else // Electric
            {
                Messages.LeftBattery();
                float LeftBattery;
                float.TryParse(Console.ReadLine(), out LeftBattery);
                io_Vehicle.Engine.CurrentEnergy = LeftBattery;

            }

            if (i_VehcileType == VehicleFactory.eVehicleType.Motorcycle)
            {
                Messages.MotorcycleLicenseType();
                Motorcycle.eLicenseType licenseType;
                Enum.TryParse(Console.ReadLine(), out licenseType);
                (io_Vehicle as Motorcycle).LicenseType = licenseType;

                Messages.EngineVolume();
                int engineVolume;
                Int32.TryParse(Console.ReadLine(), out engineVolume);
                (io_Vehicle as Motorcycle).EngineCapacity = engineVolume;

            }
            else if (i_VehcileType == VehicleFactory.eVehicleType.Car)
            {
                Messages.CarColor();
                Car.eColor color;
                Enum.TryParse(Console.ReadLine(), out color);
                (io_Vehicle as Car).Color = color;

                Messages.CarNumOfDoors();
                Car.eNumOfDoors doors;
                Enum.TryParse(Console.ReadLine(), out doors);
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
                else // "2"
                {
                    (io_Vehicle as Truck).IsContainingRefrigiratedContent = false;
                }


                Messages.TruckCargoVolume();
                float cargoVolume;
                float.TryParse(Console.ReadLine(), out cargoVolume);
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
            float.TryParse(Console.ReadLine(), out wheelPressure);
            foreach (Wheel wheel in io_Vehicle.Wheels)
            {
                wheel.CurrentAirPressure = wheelPressure;
            }

            io_Owner.Vehicle = io_Vehicle;
        }

        private static OwnerDetails OwnerDetailsRequest()
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

        private static void GetVehcileType(out VehicleFactory.eVehicleType vehcileType, out VehicleFactory.eEngineType engineType)
        {
            int vehcileTypeInt, engineTypeInt;
            Messages.diaplayVehicleTypes();
            Int32.TryParse(Console.ReadLine(), out vehcileTypeInt); // Exception or if/else
            vehcileType = (VehicleFactory.eVehicleType)vehcileTypeInt;
            if (vehcileType != VehicleFactory.eVehicleType.Truck)
            {
                Messages.diaplayEngineTypes();
                Int32.TryParse(Console.ReadLine(), out engineTypeInt); // Exception or if/else
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
