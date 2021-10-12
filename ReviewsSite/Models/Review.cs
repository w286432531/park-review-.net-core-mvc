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
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        [Range(1, 5)]
        public int StarRating { get; set; }
    }


}
