using System;
using System.Collections.Generic;
using Ex03.GarageLogic.GarageClass;

namespace Ex03.ConsoleUI
{
    public class ConsoleUserInterface
    {
        private const int k_LicenseMaxSize = 10;
        private const int k_TimeLetUseToSeePrintsBeforeClear = 1000;
        private readonly GarageManager r_GarageManager = new GarageManager();
        private bool m_OnGoing = true;

        public void Main()
        {
            userInterfaceExecution();
        }

        private void userInterfaceExecution()
        {
            while (m_OnGoing)
            {
                MenuCollection.PrintMainMenu();
                MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userInput, MenuCollection.k_MainMenuMaxOption);
                Console.Clear();
                executeByUserChoice(userInput.ToString());
                Console.Clear();
            }
        }

        private void executeByUserChoice(string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "1":
                    Console.WriteLine(string.Format("Adding a new car to the garage..."));
                    break;
                case "2":
                    displayCarsByFilter();
                    break;
                case "3":
                    changeVehicleStatus();
                    System.Threading.Thread.Sleep(k_TimeLetUseToSeePrintsBeforeClear);
                    break;
                case "4":
                    inflateTires();
                    break;
                case "5":
                    refuelVehicle();
                    break;
                case "6":
                    rechargeVehicle();
                    break;
                case "7":
                    printCarDetails();
                    break;
                case "8":
                    m_OnGoing = false;
                    break;
                default:
                    throw new ArgumentException("Invalid choice. Please select a number from 1 to 8.");
                    break;
            }
        }

        private void printCarDetails()
        {
            Console.WriteLine("What is the license number of the vehicle you want to get information about?");
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int licenseNumber, k_LicenseMaxSize);
            Console.Clear();
            Console.WriteLine(r_GarageManager.GetDataOnVehicleByLicenseNumber(licenseNumber.ToString()));
        }

        private void refuelVehicle()
        {
            Console.WriteLine("What is the license number of the vehicle you want to refuel?");
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int licenseNumber, k_LicenseMaxSize);
            Console.Clear();
            MenuCollection.PrintGasMenu();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int fuelChoice, MenuCollection.k_GasMenuMaxOption);
            Console.Clear();
            Console.WriteLine("How much fuel to refuel?");
            checkFloatParsing(Console.ReadLine(), out float fuelToRefuel);
            Console.Clear();
            r_GarageManager.RefuelVehicle(licenseNumber.ToString(), fuelToRefuel, (FuelType)fuelChoice);
        }

        private void rechargeVehicle()
        {
            Console.WriteLine("What is the license number of the vehicle you want to refuel?");
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int licenseNumber, k_LicenseMaxSize);
            Console.Clear();
            Console.WriteLine("How many minutes would you like to charge the car?");
            checkFloatParsing(Console.ReadLine(), out float minToCharge);
            r_GarageManager.RefuelVehicle(licenseNumber.ToString(), minToCharge, FuelType.Electricity);
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
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int licenseNumber, k_LicenseMaxSize);
            r_GarageManager.FillTires(licenseNumber.ToString());
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Please enter a license number");
            string licenseNumberInput = Console.ReadLine();

            VehicleStatus newStatus = getNewStatus();
            Tuple<VehicleStatus, VehicleStatus> BeforeAndAfterStatus = r_GarageManager.ChangeVehicleStatus(licenseNumberInput, newStatus);
            Console.WriteLine(string.Format("{0}------>{1}", BeforeAndAfterStatus.Item1, BeforeAndAfterStatus.Item2));
            System.Threading.Thread.Sleep(1500);
        }

        private VehicleStatus getNewStatus()
        {
            MenuCollection.PrintStatusMenu();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int choice, MenuCollection.k_StatusMenuMaxOption);

            return (VehicleStatus)choice;
        }

        private void displayCarsByFilter()
        {
            List<string> licenseNumber;

            MenuCollection.PrintFilterMenu();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userInput, MenuCollection.k_FilterMenuMaxOption);
            Console.Clear();
            switch (userInput.ToString())
            {
                case "1":
                    printList(r_GarageManager.GetAllVehicleLicenseNumberInGarage());
                    break;
                case "2":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Repair));
                    break;
                case "3":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Fixed));
                    break;
                case "4":
                    printList(r_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Paid));
                    break;
                case "5":
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private void printList(List<string> lst)
        {
            foreach (string valueToPrint in lst)
            {
                Console.WriteLine(valueToPrint);
            }
        }
    }
}
