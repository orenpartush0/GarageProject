using System;
using System.Collections.Generic;
using Ex03.GarageLogic.GarageClass;

namespace Ex03.ConsoleUI
{
    public class ConsoleUserInterface
    {
        GarageManager m_GarageManager = new GarageManager();

        public void Main()
        {
            userInterfaceExecution();
        }

        private void userInterfaceExecution()
        {
            printMenu();
            string userInput = Console.ReadLine();
            Console.Clear();
            executeByUserChoice(userInput);
        }

        private void printMenu()
        {
            string menu = string.Format(
                "Please select an option:\n" + "1. Add a new car to the garage.\n"
                                             + "2. Display the list of cars in the garage with the option to filter by their status.\n"
                                             + "3. Change the status of a car in the garage.\n"
                                             + "4. Inflate the tires of a car to maximum pressure.\n"
                                             + "5. Refuel a gasoline-powered car.\n" + "6. Charge an electric car.\n"
                                             + "7. Display full data by license plate number.\n"
                                             + "Enter your choice (1-7):");

            Console.WriteLine(menu);
        }

        private void executeByUserChoice(string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "1":
                    Console.WriteLine(string.Format("Adding a new car to the garage..."));
                    break;
                case "2":
                    Console.WriteLine(
                        string.Format("Displaying the list of car license number in the garage with filtering options"));
                    break;
                case "3":
                    Console.WriteLine(string.Format("Changing the status of a car in the garage..."));
                    break;
                case "4":
                    Console.WriteLine(string.Format("Inflating the tires of a car to maximum pressure..."));
                    break;
                case "5":
                    Console.WriteLine(string.Format("Refueling a gasoline-powered car..."));
                    break;
                case "6":
                    Console.WriteLine(string.Format("Charging an electric car..."));
                    break;
                case "7":
                    Console.WriteLine(string.Format("Displaying full data by license plate number..."));
                    break;
                default:
                    Console.WriteLine(string.Format("Invalid choice. Please select a number from 1 to 7."));
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    userInterfaceExecution();
                    break;
            }
        }

        void printFilterMenu()
        {
            string filterMenu = string.Format(
                "Please select an option:\n"
                + "1. Show all cars.\n"
                + "2. Show cars under repair.\n"
                + "3. Show cars fixed.\n"
                + "4. Show cars paid.\n"
                + "5. Exit."
                + "Enter your choice (1-5):");
            Console.WriteLine(filterMenu);
        }

        private void displayCarsByFilter()
        {
            List<string> licenseNumber;

            printFilterMenu();
            string userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    printList(m_GarageManager.GetAllVehicleLicenseNumberInGarage());
                    break;
                case "2":
                    printList(m_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Repair));
                    break;
                case "3":
                    printList(m_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Fixed));
                    break;
                case "4":
                    printList(m_GarageManager.GetVehicleLicenseNumberListWithFiltering(VehicleStatus.Paid));
                    break;
                case "5":
                    Console.Clear();
                    userInterfaceExecution();
                    break;
                default:
                    Console.WriteLine(string.Format("Invalid choice"));
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    displayCarsByFilter();
                    break;
            }
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
