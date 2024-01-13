using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class ManagerRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\managers.json";
        private List<Manager> manager = new List<Manager>();

        public ManagerRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    manager = JsonConvert.DeserializeObject<List<Manager>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(manager);
            File.WriteAllText(fileLocation, json);
        }

        public List<Manager> GetAll()
        {
            ReadJson();
            return manager;
        }

        public Manager GetById(int id)
        {
            ReadJson();
            return manager.Find(obj => obj.User.Id == id);
        }
    }
}

