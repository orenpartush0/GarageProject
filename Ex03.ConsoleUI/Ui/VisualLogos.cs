﻿using System;
using System.Text;


namespace Ex03.ConsoleUI.Ui
{
    internal class VisualLogos
    {
        public static void printOpening()
        {
            StringBuilder opening = new StringBuilder();
            opening.Append(@"
                    ▄▄▄█████▓ ██░ ██ ▓█████      ▄████  ▄▄▄       ██▀███   ▄▄▄        ▄████ ▓█████ 
                    ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀     ██▒ ▀█▒▒████▄    ▓██ ▒ ██▒▒████▄     ██▒ ▀█▒▓█   ▀ 
                    ▒ ▓██░ ▒░▒██▀▀██░▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██ ░▄█ ▒▒██  ▀█▄  ▒██░▄▄▄░▒███   
                    ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██▀▀█▄  ░██▄▄▄▄██ ░▓█  ██▓▒▓█  ▄ 
                      ▒██▒ ░ ░▓█▒░██▓░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒░██▓ ▒██▒ ▓█   ▓██▒░▒▓███▀▒░▒████▒
                      ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ░▒   ▒ ░░ ▒░ ░
                    ░     ▒ ░▒░ ░ ░ ░  ░     ░   ░   ▒   ▒▒ ░  ░▒ ░ ▒░  ▒   ▒▒ ░  ░   ░  ░ ░  ░
                    ░       ░  ░░ ░   ░      ░ ░   ░   ░   ▒     ░░   ░   ░   ▒   ░ ░   ░    ░   
                    ░  ░  ░   ░  ░         ░       ░  ░   ░           ░  ░      ░    ░  ░
                ");
            Console.WriteLine(opening);
            Console.WriteLine("Type any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public static void printClosing()
        {
            StringBuilder closing = new StringBuilder();
            closing.Append(@"
                     ▄▄▄▄▄▄▄▄▄▄   ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄   ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄ 
                    ▐░░░░░░░░░░▌ ▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌ ▐░▌       ▐░▌▐░░░░░░░░░░░▌
                    ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀ 
                    ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌               ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          
                    ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ 
                    ▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
                    ▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ 
                    ▐░▌       ▐░▌     ▐░▌     ▐░▌               ▐░▌       ▐░▌     ▐░▌     ▐░▌          
                    ▐░█▄▄▄▄▄▄▄█░▌     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄ 
                    ▐░░░░░░░░░░▌      ▐░▌     ▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌      ▐░▌     ▐░░░░░░░░░░░▌
                     ▀▀▀▀▀▀▀▀▀▀        ▀       ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀        ▀       ▀▀▀▀▀▀▀▀▀▀▀ 
                ");
            Console.WriteLine(closing);
            Console.WriteLine("Type any key to continue");
            Console.ReadLine();
        }
    }
}
