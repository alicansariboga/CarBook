using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACar
    {
        [Key]
        public int RenACarID { get; set; }
        public int PickUplocationID { get; set; }
        [ForeignKey("PickUplocationID")]
        public Location Location { get; set; }
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public Car Car { get; set; }
        public bool Available { get; set; }
    }
}
