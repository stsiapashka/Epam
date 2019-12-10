using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class UserCreator
    {
       public static User WithCredentialsFromProperty()
       {
            return new User(TestDataReader.GetTestData("login"),TestDataReader.GetTestData("password"));
       }
    }
}
