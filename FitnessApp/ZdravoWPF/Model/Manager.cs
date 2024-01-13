using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Manager
    {
        public Manager() { }

        public Manager(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            User newUser = new User(jmbg, username, password, name, surname, email, address, phone, dataOfBirth);
            this.User = newUser;
        }

        public Manager(User user)
        {
            this.User = user;
        }


        public Manager(string jmbg, string username, string password, string name, string surname)
        {
            User newUser = new User(jmbg, username, password, name, surname);
            this.User = newUser;
        }


        public User User { get; set; }
    }
}
