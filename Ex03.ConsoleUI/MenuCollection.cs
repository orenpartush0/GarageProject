using System;


namespace Ex03.ConsoleUI
{
    public class MenuCollection
    {

        public const int k_GasMenuMaxOption = 4;
        public const int k_FilterMenuMaxOption = 4;
        public const int k_MainMenuMaxOption = 8;
        public const int k_StatusMenuMaxOption = 3;


        public void PrintMenu<T>() where T : Enum
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

        public void CheckUserInput(string i_NeedToParsed, out int o_Parsed, int i_MaxOption)
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
