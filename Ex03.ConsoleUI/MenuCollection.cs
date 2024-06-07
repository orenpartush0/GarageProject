using System;


namespace Ex03.ConsoleUI
{
    internal class MenuCollection
    {

        public const int k_GasMenuMaxOption = 4;
        public const int k_FilterMenuMaxOption = 5;
        public const int k_MainMenuMaxOption = 8;
        public const int k_StatusMenuMaxOption = 3;

        public static void PrintGasMenu()
        {
            Console.WriteLine(string.Format(
                  "Which type of fuel would you like to refuel with?\n"
                + "Please select an option:\n"
                + "1. Soler.\n"
                + "2. Octan95.\n"
                + "3. Octan96.\n"
                + "4. Octan98.\n"
                + "Enter your choice (1-4):"));
        }

        public static void PrintFilterMenu()
        {
            Console.WriteLine(string.Format(
                "Please select an option:\n"
                + "1. Show all cars.\n"
                + "2. Show cars under repair.\n"
                + "3. Show cars fixed.\n"
                + "4. Show cars paid.\n"
                + "5. Exit."
                + "Enter your choice (1-5):"));
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine(string.Format(
                "Please select an option:\n"
                + "1. Add a new car to the garage.\n"
                + "2. Display the list of cars in the garage with the option to filter by their status.\n"
                + "3. Change the status of a car in the garage.\n"
                + "4. Inflate the tires of a car to maximum pressure.\n"
                + "5. Refuel a gasoline-powered car.\n" + "6. Charge an electric car.\n"
                + "7. Display full data by license plate number.\n"
                + "8. Exit"
                + "Enter your choice (1-7):"));
        }

        public static void PrintStatusMenu()
        {
            Console.WriteLine(string.Format(
                  "Choose the new status for the vehicle::\n"
                + "1. Repair.\n"
                + "2. Fixed.\n"
                + "3. Paid.\n"
                + "Enter your choice (1-3):"));
        }

        public static void CheckUserInputByMenu(string i_NeedToParsed, out int o_Parsed, int i_MaxOption)
        {
            if (!int.TryParse(i_NeedToParsed, out o_Parsed))
            {
                throw new FormatException("Invalid choice");
            }
            else if (o_Parsed > i_MaxOption)
            {
                throw new ArgumentException("Invalid choice");
            }
        }
    }
}
