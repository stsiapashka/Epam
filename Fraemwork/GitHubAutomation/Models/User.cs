using System;
using System.Text;


namespace GitHubAutomation.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
