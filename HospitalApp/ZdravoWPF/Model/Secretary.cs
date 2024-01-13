using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Secretary
    {
        public User User { get; set; }

        public Secretary() { }

        public Secretary(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            User newUser = new User(jmbg, username, password, name, surname, email, address, phone, dataOfBirth);
            this.User = newUser;
        }

        public Secretary(string jmbg, string username, string password, string name, string surname)
        {
            User newUser = new User(jmbg, username, password, name, surname);
            this.User = newUser;
        }





    }
}
