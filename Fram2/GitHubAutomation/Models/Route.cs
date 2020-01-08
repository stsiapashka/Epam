using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class Route
    {
        public string departurecity { get; set; }
        public string cityofarrival { get; set; }

        public Route(string departurecity, string cityofarrival)
        {
            this.departurecity = departurecity;
            this.cityofarrival = cityofarrival;
        }
    }
}
