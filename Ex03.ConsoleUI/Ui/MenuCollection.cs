using System;


namespace Ex03.ConsoleUI
{
    public class MenuCollection
    {

        public const int k_GasMenuMaxOption = 4;
        public const int k_FilterMenuMaxOption = 4;
        public const int k_MainMenuMaxOption = 8;
        public const int k_StatusMenuMaxOption = 3;
        public const int k_VehicleNum = 5;
        public const int k_ColorsMenuMaxOption = 4;
        public const int k_DoorsMenuMaxOption = 4;
        public const int k_LicenseTypeMenuMaxOption = 4;



        public static void PrintMenu<T>() where T : Enum
        {
            var enumType = typeof(T);
            var names = Enum.GetNames(enumType);
            int index = 1;

            Console.WriteLine("Please select an option:");
            foreach (var name in names)
            {
                string formattedName = name.Replace('_', ' ');
                Console.WriteLine($"{index}. {formattedName}.");
                index++;
            }

            Console.WriteLine($"Enter your choice (1-{names.Length}):");
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
