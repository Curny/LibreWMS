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

            // Assembly.GetEntryAssembly().GetName().Version

            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            

            return $"{ assemName.Name } { ver.ToString() }";
        }
    }

    
}
