using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Park
    {
        public int Id { get; set; } //Always start with ID
        public string Name { get; set; }
        public bool HasHandicapAccess { get; set; }
        public bool IsDogFriendly { get; set; }
        public string ParkType { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}