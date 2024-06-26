﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.ConsoleUI.FactoryClass;
using Ex03.GarageLogic.GarageClass;

namespace Ex03.ConsoleUi.UI
{
    public class ConsoleUserInterface
    {
        private const int k_LicenseMaxSize = 8;//Israeli Standard
        private readonly GarageManager r_GarageManager = new GarageManager();
        private bool m_OnGoing = true;

        enum eSec
        {
            Sec = 1000,
            TwoSec = 2000,
        }

        private void checkLicense(string i_LicenseNumber, bool i_CalledByAddVehicle = false)
        {
            if (i_LicenseNumber.Length != k_LicenseMaxSize || !i_LicenseNumber.All(char.IsDigit))
            {
                throw new ArgumentException("invalid license number");
            }

            if(!i_CalledByAddVehicle) {
                r_GarageManager.CheckIfVehicleIsServiced(i_LicenseNumber);
            }
        }

        public void UserInterfaceExecution()
        {
            while (m_OnGoing)
            {
                try
                {
                    MenuCollection.PrintMenu<eGarageMenuOptions>();
                    MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userInput, MenuCollection.k_MainMenuMaxOption);
                    Console.Clear();
                    executeByUserChoice(userInput.ToString());
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep((int)eSec.TwoSec);
                    Console.Clear();
                }
            }
        }

        private void executeByUserChoice(string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "1":
                    addVehicle();
                    break;
                case "2":
                    displayCarsByFilter();
                    break;
                case "3":
                    changeVehicleStatus();
                    break;
                case "4":
                    inflateTires();
                    break;
                case "5":
                    refuelOrRecharge(true);
                    break;
                case "6":
                    refuelOrRecharge(false);
                    break;
                case "7":
                    printCarDetails();
                    break;
                case "8":
                    m_OnGoing = false;
                    break;
                default:
                    throw new ArgumentException("Invalid choice. Please select a number from 1 to 8.");
            }
        }

        private void printCarDetails()
        {
            Console.WriteLine("What is the license number of the vehicle you want to get information about?(8 digits)");
            string licenseNumber = Console.ReadLine();
            checkLicense(licenseNumber);
            Console.Clear();
            Console.WriteLine(r_GarageManager.GetDataOnVehicleByLicenseNumber(licenseNumber));
            Console.ReadLine();
        }

        private void visualProcess(string i_Msg)
        {
            Console.Write(i_Msg);
            System.Threading.Thread.Sleep((int)eSec.Sec);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep((int)eSec.Sec);
            }
            Console.WriteLine("\nDone!");
            System.Threading.Thread.Sleep((int)eSec.Sec);
            Console.Clear();
        }

        private void refuelOrRecharge(bool i_IsRefuel)
        {
            int fuelChoice = 1;
            Console.WriteLine("What is the license number of the vehicle you want to " + (i_IsRefuel ? "refuel?" : "recharge?"));
            string licenseNumber = Console.ReadLine();
            checkLicense(licenseNumber);
            Console.Clear();

            if (i_IsRefuel)
            {
                MenuCollection.PrintMenu<eFuelType>();
                MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out fuelChoice, MenuCollection.k_GasMenuMaxOption);
                Console.Clear();
                Console.WriteLine("How much fuel to refuel?");
            }
            else
            {
                Console.WriteLine("How many hours would you like to charge the car?");
            }

            checkFloatParsing(Console.ReadLine(), out float amountToCharge);

            Tuple<float, float> beforeAndAfterCharge = i_IsRefuel ?
                                                           r_GarageManager.RefuelVehicle(licenseNumber, amountToCharge, (eFuelType)fuelChoice) :
                                                           r_GarageManager.RefuelVehicle(licenseNumber, amountToCharge, null);

            visualProcess(i_IsRefuel ? "Fueling" : "Charging");
            Console.WriteLine($"{(i_IsRefuel ? "Fuel tank" : "Battery")} status: {beforeAndAfterCharge.Item1}/{beforeAndAfterCharge.Item2}");
            System.Threading.Thread.Sleep((int)eSec.TwoSec);
        }


        private void checkFloatParsing(string i_NeedToParsed, out float o_Parsed)
        {
            if (!float.TryParse(i_NeedToParsed, out o_Parsed))
            {
                throw new FormatException("Invalid choice");
            };
        }

        private void inflateTires()
        {
            Console.WriteLine("What is the license number of the vehicle you want to fill the tires with air?");
            string licenseNumber = Console.ReadLine();
            checkLicense(licenseNumber);
            float? newAirPressure = r_GarageManager.FillTires(licenseNumber);
            visualProcess("Inflate the tires to Max");
            Console.WriteLine($"New air pressure in the wheels: {newAirPressure}");
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Please enter a license number");
            string licenseNumber = Console.ReadLine();
            checkLicense(licenseNumber);
            eVehicleStatus newStatus = getNewStatus();
            Tuple<eVehicleStatus, eVehicleStatus> beforeAndAfterStatus = r_GarageManager.ChangeVehicleStatus(licenseNumber, newStatus);
            Console.WriteLine(string.Format("{0}------>{1}", beforeAndAfterStatus.Item1, beforeAndAfterStatus.Item2));
            Console.ReadLine();
        }

        private eVehicleStatus getNewStatus()
        {
            MenuCollection.PrintMenu<eVehicleStatus>();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int choice, MenuCollection.k_StatusMenuMaxOption);

            return (eVehicleStatus)choice;
        }

        private void displayCarsByFilter()
        {
            MenuCollection.PrintMenu<eFilter>();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userInput, MenuCollection.k_FilterMenuMaxOption);
            Console.Clear();
            switch (userInput.ToString())
            {
                case "1":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering());
                    break;
                case "2":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(eVehicleStatus.Repair));
                    break;
                case "3":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(eVehicleStatus.Fixed));
                    break;
                case "4":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(eVehicleStatus.Paid));
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private void printList(List<string> i_Lst)
        {
            Console.WriteLine($"List of license number filtered by your request:");
            foreach (string valueToPrint in i_Lst)
            {
                Console.WriteLine(valueToPrint);
            }
        }

        private void addVehicle()
        {
            Console.WriteLine("Please enter the license number of the vehicle (8 digits)");
            string licenseNumber = Console.ReadLine();
            checkLicense(licenseNumber, true);
            Console.Clear();
            if (!r_GarageManager.IsInGarage(licenseNumber))
            {
                Console.WriteLine("Please enter the vehicle type");
                MenuCollection.PrintMenu<eVehicle>();
                MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int vehicleChoice, MenuCollection.k_VehicleNum);
                Console.Clear();
                Factory factory = Factory.createFactory((eVehicle)vehicleChoice);
                factory.SetVehicleData((eVehicle)vehicleChoice, licenseNumber, r_GarageManager);
            }
        }
    }
}
