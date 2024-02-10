using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        [Key]
        public int RenACarProcessID { get; set; }

        [ForeignKey("CarID")]
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PickUpLocation { get; set; }
        public int DropOffLocation { get; set; }

        //SOLID principles were violated.
        [Column(TypeName = "Date")]
        public DateTime PickUpDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan PickUpTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DropOffTime { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string PickUpDescription { get; set; } // damage/change etc.
        public string DropOffDescription { get; set; } // damage/change etc.
        public decimal TotalPrice { get; set; }
    }
}
