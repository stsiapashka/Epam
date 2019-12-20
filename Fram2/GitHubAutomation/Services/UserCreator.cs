using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class UserCreator
    {
        public static User WithCredentialsFromProperty()
        {
            return new User(TestDataReader.GetTestData("name"), TestDataReader.GetTestData("surname"),
                TestDataReader.GetTestData("birthday"),
                TestDataReader.GetTestData("passport"),
                TestDataReader.GetTestData("login"),
                TestDataReader.GetTestData("password"),
                TestDataReader.GetTestData("numphone"));
        }
        public static User UserKardInfo()
        {
            return new User(TestDataReader.GetTestData("numсard"), TestDataReader.GetTestData("сardmonth"),
                            TestDataReader.GetTestData("сardyear"),
                            TestDataReader.GetTestData("сardname"));
        }       
    }
}
