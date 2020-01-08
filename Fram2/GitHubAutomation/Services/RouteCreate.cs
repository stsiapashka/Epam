using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class RouteCreate
    {
        public static Route WithCredentialsFromProperty()
        {
            return new Route(TestDataReader.GetTestData("departurecity"),
                TestDataReader.GetTestData("cityofarrival"));
        }               
    }
}
