using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FirstWorldWar_SpecFlow.DataProviders
{
    class ConfigFileReader
    {
        Dictionary<string, string> properties = new Dictionary<string, string>();
        string fileName = @"C:\\Users\\JZiesel\\Documents\\Visual Studio 2019\\Projects\\FirstWorldWar_SpecFlow\\Configuration.properties";

        public ConfigFileReader()
        {
            //FileStream fs = File.OpenRead(fileName);   //File.OpenWrite(fileName);
            foreach (var row in File.ReadAllLines(fileName))
                properties.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

            Console.WriteLine(properties["browser"]);

        }

        public string getBrowser()
        {
            return properties["browser"];
        }
    }
}
