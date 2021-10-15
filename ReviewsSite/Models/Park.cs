using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Park
    {
        public int Id { get; set; } //Always start with ID
        [Required]
        public string Name { get; set; }
        [Display(Name = "Handicap Access")]
        public bool HasHandicapAccess { get; set; }
        [Display(Name = "Dog Friendly")]
        public bool IsDogFriendly { get; set; }
        [Display(Name = "Park Type")]
        public string ParkType { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}