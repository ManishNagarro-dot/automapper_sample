using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace automapper_sample.Model
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [Column("AddressId")]
        public int AddressId { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Country")]
        public string Country { get; set; }

        public int StudentID { get; set; }
    }
}
