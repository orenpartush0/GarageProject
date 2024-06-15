using Ex03.ConsoleUi.UI;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            VisualLogos.printOpening();
            ConsoleUserInterface userInterface = new ConsoleUserInterface();
            userInterface.UserInterfaceExecution();
            VisualLogos.printClosing();
        }
    }
}
