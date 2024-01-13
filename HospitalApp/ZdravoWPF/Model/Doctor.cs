using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Doctor
    {
        private String specialization { get; set; }
        public User User { get; set; }

        public Doctor() { }

        public Doctor(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dateOfBirth, string specialization)
        {
            User newUser = new User(jmbg, username, password, name, surname, email, address, phone, dateOfBirth);
            this.User = newUser;
            this.specialization = specialization;
        }

        public Doctor(User user)
        {
            this.User = user;
        }


        public Doctor(string jmbg, string username, string password, string name, string surname)
        {
            User newUser = new User(jmbg, username, password, name, surname);
            this.User = newUser;
        }

        public Doctor(User user, string specialization)
        {
            this.User = user;
            this.specialization = specialization;
        }
    }
}
