using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Park Description")]
        [DataType(DataType.MultilineText)]
        public string ParkDescription { get; set; }
        public virtual List<Review> Reviews { get; set; }
        [NotMapped]
        [Display(Name = "Rating")]
        public virtual double AverageRating { get; set; }
        public void GetAverage()
        {
            if(Reviews.Count > 0)
            {
                AverageRating = Math.Round(Reviews.Select(r => r.StarRating).Average(), 1);
            }
            else
            {
                AverageRating = 0;
            }
            
        }
        
    }
}