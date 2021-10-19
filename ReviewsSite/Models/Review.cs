using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ParkId { get; set; }
        public virtual Park Park { get; set; }
        [Display(Name = "Reviewer")]
        public string ReviewerName { get; set; }
        [Display(Name = "Review")]
        public string Comment { get; set; }
        [Display(Name = "Rating")]
        [Range(1, 5, ErrorMessage = "Please give this park a rating.")]
        public int StarRating { get; set; }
    }


}
