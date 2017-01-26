using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Discount { get; set; } //Percentage

        //In order to access Customer data from LINQ,
        //use int CustomerId and add this virtual accessor: 
        public virtual Customer Customer { get; set; }


        public virtual ICollection<OrderItems> Items { get; set; }
    }
}
