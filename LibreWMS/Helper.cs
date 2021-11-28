using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibreWMS
{
    public static class Helper
    {
        public static List<string> dirtyInput = new List<string>();
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string CheckForDirtyInput(string input)
        {
            bool alert = false;
            string suspiciousWord = string.Empty;
            dirtyInput.Clear();

            dirtyInput.Add("DROP");
            dirtyInput.Add("ERASE");
            dirtyInput.Add(">");

            foreach (var word in dirtyInput)
            {
                if ( input.Contains(word.ToLower()) )
                {
                    alert = true;
                    suspiciousWord = word;
                }
                
            }

            if (alert)
            {
                return suspiciousWord;
            }
            else
            {
                return "safe";
            }
            
        }

        public static String GetVersion()
        {
            // --------------------------------------------------------------------------------
            // this throws the wrong number on Mac and Linux, therefore manually below....
            // --------------------------------------------------------------------------------
            // Assembly assem = Assembly.GetExecutingAssembly();
            // AssemblyName assemName = assem.GetName();
            // Version ver = assemName.Version;
            // return $"{ assemName.Name } { ver.ToString() }";
            // --------------------------------------------------------------------------------

            // I do this because on Mac and Linux the Version number is not displayed correctly otherwise.
            // have to find out why later, it's not so important....
            Version libreWMSver = new Version("0.1.0.0");
            return $"LibreWMS { libreWMSver } PreAlpha";
            
        }
    }

    
}
