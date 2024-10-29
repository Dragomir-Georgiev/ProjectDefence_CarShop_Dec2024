using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class FeedBack
    {
        public Guid Id { get; set; }
        //TODO ADD USER 

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
