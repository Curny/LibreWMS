using System;
using System.Reflection;
namespace LibreWMS
{
    public class MenuHeader
    {

        public MenuHeader()
        {

        }

        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("LibreWMS " + typeof(LibreWMS.MainClass).Assembly.GetName().Version + "\t\t" + Menu.currentMenu);
            Console.WriteLine();
        }

        
    }
}
