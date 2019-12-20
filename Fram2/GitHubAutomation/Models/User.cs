using System;
using System.Text;


namespace GitHubAutomation.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birthday { get; set; }
        public string passport { get; set; }
        public string numphone { get; set; }

        public string numсard { get; set; }
        public string сardmonth { get; set; }
        public string сardyear { get; set; }
        public string сardname { get; set; }

        public User(string name, string surname, string birthday, string passport,string numphone, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
            this.passport = passport;
            this.login = login;
            this.password = password;
            this.numphone = numphone;

        }
        public User(string numсard, string сardmonth, string сardyear, string сardname)
        {
            this.numсard = numсard;
            this.сardmonth = сardmonth;
            this.сardyear = сardyear;
            this.сardname = сardname;
        }
    }
}
