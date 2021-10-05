using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Review
    {
        public virtual Park Park { get; set; }
        public int ParkId { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
        public int Id { get; set; }
        public int StarRating { get; set; }


    }
}
