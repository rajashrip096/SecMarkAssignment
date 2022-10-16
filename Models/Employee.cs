using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecMarkAssignment.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]

        [Required(ErrorMessage = "emp code is required")]
        public string Emp_code { get; set; }
        [Required(ErrorMessage = "emp name is required")]
        public string? Emp_Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage ="emp dept is required")]
        public string Emp_dept { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }

    }
}
