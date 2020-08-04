using System;

namespace LibreWMS
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Menu.MainMenu();

            if (!string.IsNullOrEmpty(Menu.menuChoice))
            {
                Console.WriteLine(Menu.menuChoice);
            }
        }
    }
}
