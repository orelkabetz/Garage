using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    static class Messages
    {
        public static void Hello()
        {
            Console.Clear();
            string hello = string.Format(
@" 
         Hello and Welcome to 
            Elkabetz@Sharf 
                Garage
                    
");
            Console.WriteLine(hello);
            System.Threading.Thread.Sleep(2000);
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            string menu = string.Format(
@" 
          What Would You Like To Do?
        (1) Add a vehicle to the garage
        (2) Display vehicles
        (3) Change a vehicle's state
        (4) Inflate a vheicle's wheels
        (5) Fuel a vehicle
        (6) Charge a vehicle
        (7) Display a vehicle's details
        (8) Esc
                    ");
            Console.WriteLine(menu);
        }

        public static void ByeBye()
        {
            Console.Clear();
            string bye = string.Format(
@" 
         Thank for visiting us at 
              Elkabetz@Sharf 
                  Garage

                 BYE BYE!
                    
");
            Console.WriteLine(bye);
        }

        public static void InvalidChoice()
        {
            Console.Clear();
            string invalidCohice = string.Format(
@" 
         This is an invalid choice,
            Please try again:
");
            Console.WriteLine(invalidCohice);
            PressAnyKey();
        }

        public static void FormatException(FormatException exception)
        {
            Console.Clear();
            string exceptionString = string.Format(
            @"{0}, {1}:", exception.Source, exception.Message );
            Console.WriteLine(exceptionString);
            System.Threading.Thread.Sleep(3000);
        }

        public static void ArgumentException(ArgumentException exception)
        { 
            Console.Clear();
            string exceptionString = string.Format(
            @"{0}, {1}:", exception.ParamName, exception.Message);
            Console.WriteLine(exceptionString);
            System.Threading.Thread.Sleep(3000);

        }

        public static void ValueOutOfRangeException(ValueOutOfRangeException exception)
        {
            Console.Clear();
            string exceptionString = string.Format(
            @"{0}, {1}:", exception.Source, exception.Message);
            Console.WriteLine(exceptionString);
            System.Threading.Thread.Sleep(3000);
        }

        public static void diaplayVehicleTypes()
        {
            Console.Clear();
            string type = string.Format(
@" 
         Please Choose the type of the vehicle:
            (1) Motorcycle
            (2) Car
            (3) Truck
");
            Console.WriteLine(type);
        }

        public static void diaplayEngineTypes()
        {
            Console.Clear();
            string type = string.Format(
@" 
         Please Choose the type of the engine:
            (1) Gas
            (2) Electric
");
            Console.WriteLine(type);
        }

        public static void DisplayLicensePlatesMenu()
        {
            Console.Clear();
            string licensePlateMenu = string.Format(
@" 
         Please choose the list of vehicles you would like to see:
            (1) Vehicles in Fixing
            (2) Completed Fixing Vehicles
            (3) Paid To Garage Vehicles
            (4) All The Vehicles In The Garage
");
            Console.WriteLine(licensePlateMenu);
        }

        public static void ChargeAmount()
        {
            Console.Clear();
            string chargeAmount = string.Format(
@" 
        Please enter the amount of battery time you would like to add:"
);
            Console.WriteLine(chargeAmount);
        }

        public static void FuelType()
        {
            Console.Clear();
            string fuelType = string.Format(
@" 
         Please choose the fuel type you would like to add:
            (1) Soler
            (2) Octan95
            (3) Octan96
            (4) Octan98
");
            Console.WriteLine(fuelType);
        }

        public static void SetVehicleState()
        {
            Console.Clear();
            string setVehicleState = string.Format(
@" 
         Please choose the state you would like to change the vehicle to:
            (1) Fixing
            (2) Completed
            (3) Paid
");
            Console.WriteLine(setVehicleState);
        }

        public static void FuelAmount()
        {
            Console.Clear();
            string fuelAmount = string.Format(
@" 
        Please enter the amount of fuel you would like to add:"
);
            Console.WriteLine(fuelAmount);
        }

        public static void LicensePlateNumber()
        {
            Console.Clear();
            string licensePlateNumber = string.Format(
@" 
        Please enter the license plate number:"
);
            Console.WriteLine(licensePlateNumber);
        }

        public static void ModelName()
        {
            Console.Clear();
            string modelName = string.Format(
@" 
        Please enter the model name:"
);
            Console.WriteLine(modelName);
        }

        public static void LeftGas()
        {
            Console.Clear();
            string leftGas = string.Format(
@" 
        Please enter how much gas left:"
);
            Console.WriteLine(leftGas);
        }

        public static void LeftBattery()
        {
            Console.Clear();
            string leftBattery = string.Format(
@" 
        Please enter how much battery left:"
);
            Console.WriteLine(leftBattery);
        }

        public static void MotorcycleLicenseType()
        {
            Console.Clear();
            string type = string.Format(
@" 
         Please Choose the type of the license:
            (1) A
            (2) A1
            (3) B1
            (4) BB
");
            Console.WriteLine(type);
        }

        public static void EngineVolume()
        {
            Console.Clear();
            string engineVolume = string.Format(
@" 
        Please enter the engine volume:"
);
            Console.WriteLine(engineVolume);
        }

        public static void CarColor()
        {
            Console.Clear();
            string color = string.Format(
@" 
         Please Choose the color of the car:
            (1) Red
            (2) White
            (3) Green
            (4) Blue
");
            Console.WriteLine(color);
        }

        public static void CarNumOfDoors()
        {
            Console.Clear();
            string doorNumber = string.Format(
@" 
         Please Choose the number of doors in the car:
            (2) Two
            (3) Three
            (3) Four
            (5) Five
");
            Console.WriteLine(doorNumber);
        }

        public static void TruckRefrigirated()
        {
            Console.Clear();
            string refrigirated = string.Format(
@" 
         Does the truck refrigirated?
            (1) Yes
            (2) No
");
            Console.WriteLine(refrigirated);
        }

        public static void TruckCargoVolume()
        {
            Console.Clear();
            string cargoVolume = string.Format(
@" 
        Please enter the truck cargo volume:"
);
            Console.WriteLine(cargoVolume);
        }

        public static void WheelManufacturer()
        {
            Console.Clear();
            string wheelManufacturerName = string.Format(
@" 
        Please enter the wheel manufacturer name:"
);
            Console.WriteLine(wheelManufacturerName);
        }

        public static void CurrentWheelPressure()
        {
            Console.Clear();
            string wheelPressure = string.Format(
@" 
        Please enter the current wheel pressure:"
);
            Console.WriteLine(wheelPressure);
        }

        public static void OwnerName()
        {
            Console.Clear();
            string ownerName = string.Format(
@" 
        Please enter the name of the owner:"
);
            Console.WriteLine(ownerName);
        }

        public static void OwnerPhoneNumber()
        {
            Console.Clear();
            string ownerPhoneNumber = string.Format(
@" 
        Please enter the phone number of the owner:"
);
            Console.WriteLine(ownerPhoneNumber);
        }

        public static void SuccsefullVehicleAdding()
        {
            Console.Clear();
            string ownerPhoneNumber = string.Format(
@" 
        Vehicle added succsefully"
);
            Console.WriteLine(ownerPhoneNumber);
            System.Threading.Thread.Sleep(2000);

        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
