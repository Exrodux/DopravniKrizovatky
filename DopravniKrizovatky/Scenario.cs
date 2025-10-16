using System.Collections.Generic;

namespace DopravniKrizovatky
{
    public class Scenario
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public string Explanation { get; set; }
    }

    public class Vehicle
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Approach { get; set; }
        public string Direction { get; set; }
    }
}
