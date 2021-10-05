using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Park
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasHandicapAccess { get; set; }
        public bool DogFriendly { get; set; }

        public ParkType ParkType { get; set; }
    }
    public enum ParkType
    {
        Museum,
        Park,
        Venue,
        HistoricalSite
    }
}
