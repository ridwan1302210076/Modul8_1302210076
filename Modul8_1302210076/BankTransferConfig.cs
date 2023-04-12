using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modul8_1302210076
{
    internal class BankTransferConfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "bank_transfer_config.json";


        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }

        public Config ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }

        public void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }


        private void SetDefault()
        {
            string lang = "id";
            Transfer transfer = new Transfer(1000000, 6500, 19500);
            List<string> methods = new List<string>();
            methods.Add("RTO (real-time)");
            methods.Add("SKN");
            methods.Add("RTGS");
            methods.Add("BI FAST");
            Confirmation confirmation = new Confirmation("yes", "ya");
            config = new BankTransfer(lang, transfer, methods, confirmation);
        }
      
        
        


    }
    


}
