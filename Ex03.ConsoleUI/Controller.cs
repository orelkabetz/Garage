using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
using Ex03;

namespace Ex03.ConsoleUI
{
    public static class Controller
    {
        public static void Run()
        {
            eUserOpstions userChoice;
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

        }

        private static void GetVehcileType(out VehicleFactory.eVehicleType vehcileType, out VehicleFactory.eEngineType engineType)
        {
            int vehcileTypeInt, engineTypeInt;
            Messages.diaplayVehicleTypes();
            Int32.TryParse(Console.ReadLine(), out vehcileTypeInt); // Exception or if/else
            vehcileType = (VehicleFactory.eVehicleType)vehcileTypeInt;
            Messages.diaplayEngineTypes();
            Int32.TryParse(Console.ReadLine(), out engineTypeInt); // Exception or if/else
            engineType = (VehicleFactory.eEngineType)engineTypeInt;
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
