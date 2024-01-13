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
    public class SecretaryRepository
    {

            private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\secretary.json";
            private List<Secretary> sec = new List<Secretary>();

            public SecretaryRepository()
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
                        sec = JsonConvert.DeserializeObject<List<Secretary>>(json);
                    }
                }
            }
            public void WriteToJson()
            {
                string json = JsonConvert.SerializeObject(sec);
                File.WriteAllText(fileLocation, json);
            }

            public List<Secretary> GetAll()
            {
                ReadJson();
                return sec;
            }

            public Secretary GetById(int id)
            {
                ReadJson();
                return sec.Find(obj => obj.User.Id == id);
            }
            public bool Save(Secretary secretary)
            {

                sec.Add(secretary);
                WriteToJson();
                return true;
            }

            public bool Delete(int id)
            {
                ReadJson();
                int index = sec.FindIndex(obj => obj.User.Id == id);
                sec.RemoveAt(index);
                WriteToJson();
                return true;
            }
        }
    }

