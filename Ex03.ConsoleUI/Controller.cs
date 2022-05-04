﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
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
                operateUserCohice(userChoice);
            } while (userChoice != eUserOpstions.Esc);
            Messages.ByeBye();
        }

        private static eUserOpstions getUserChoice()
        {
            int userChoice;
            Int32.TryParse(Console.ReadLine(), out userChoice);
            return (eUserOpstions)userChoice;
        }

        private static void operateUserCohice(eUserOpstions userChoice)
        {
            try
            {
                switch (userChoice)
                {
                    case eUserOpstions.AddVehicle:
                        addVehicle();
                        break;
                    case eUserOpstions.DisplayLicensePlates:
                        //displayLicensePlates();
                        break;
                    case eUserOpstions.SetState:
                        //setState();
                        break;
                    case eUserOpstions.InflateToMax:
                        //inflateToMax();
                        break;
                    case eUserOpstions.FuelVehicle:
                        //fuelVehicle();
                        break;
                    case eUserOpstions.ChargeVehicle:
                        //chargeVehicle();
                        break;
                    case eUserOpstions.DisplayDetails:
                        //disaplyDetails();
                        break;
                    case eUserOpstions.Esc:
                        break;
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
            catch (ValueOutOfRanfeException exception) // לטפל
            {
                Messages.ValueOutOfRanfeException(exception);
            }
            finally
            {
                Messages.DisplayMenu();
                userChoice = getUserChoice();
                operateUserCohice(userChoice);
            }
        }

        private static void addVehicle()
        {
            VehicleFactory.eVehicleType vehcileType;
            VehicleFactory.eEngineType engineType;
            GetVehcileType(out vehcileType, out engineType);
            Vehicle vehicle = VehicleFactory.CreateNewVehicle(vehcileType, engineType);
            DetailsRequest(vehcileType, engineType);

        }

        private static void DetailsRequest(VehicleFactory.eVehicleType i_VehcileType, VehicleFactory.eEngineType i_EngineType)
        {
            Messages.LicensePlateNumber();
            Console.ReadLine();
            Messages.ModelName();
            Console.ReadLine();
            if (i_EngineType == VehicleFactory.eEngineType.Gas)
            {
                Messages.GasType();
                Console.ReadLine();
                Messages.LeftGas();
                Console.ReadLine();

            }
            else // Electric
            {
                Messages.LeftBattery();
                Console.ReadLine();

            }

            if (i_VehcileType == VehicleFactory.eVehicleType.Motorcycle)
            {
                Messages.MotorcycleLicenseType();
                Console.ReadLine();


                Messages.EngineVolume();
                Console.ReadLine();

            }
            else if (i_VehcileType == VehicleFactory.eVehicleType.Car)
            {
                Messages.CarColor();
                Console.ReadLine();

                Messages.CarNumOfDoors();
                Console.ReadLine();

            }
            else // Truck
            {
                Messages.TruckRefrigirated();
                Console.ReadLine();


                Messages.TruckCargoVolume();
                Console.ReadLine();

            }

            Messages.WheelManufacturer();
            Console.ReadLine();


            Messages.CurrentWheelPressure();
            Console.ReadLine();


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
