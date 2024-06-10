using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI.Ui;

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
