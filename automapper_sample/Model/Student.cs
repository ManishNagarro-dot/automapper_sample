using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace automapper_sample.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("StudentID")]
        public int StudentID { get; set; }
        [Column("StudentName")]
        public string Name { get; set; }
        [Column("StudentAge")]
        public int Age { get; set; }
        [Column("StudentCity")]
        public string City { get; set; }
        public Address Address { get; set; }

    }
}
