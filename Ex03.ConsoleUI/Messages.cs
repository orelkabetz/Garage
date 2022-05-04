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
        (2) Display all the cars in the garage
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
        }

        public static void FormatException(FormatException exception)
        {
            Console.Clear();
            string exceptionString = string.Format(
@"{0}, {1}:", exception.Source, exception.Message );
            Console.WriteLine(exceptionString);
        }

        public static void ArgumentException(ArgumentException exception)
        { 
            Console.Clear();
            string exceptionString = string.Format(
@"{0}, {1}:", exception.ParamName, exception.Message);
        Console.WriteLine(exceptionString);
        }

        public static void ValueOutOfRanfeException(ValueOutOfRanfeException exception)
        {
            Console.Clear();
            string exceptionString = string.Format(
@"{0}, {1}:", exception.Source, exception.Message);
            Console.WriteLine(exceptionString);
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
    }
}
