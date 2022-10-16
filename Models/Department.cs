using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecMarkAssignment.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [ScaffoldColumn(false)]
        public string dept_code { get; set; }
        [Required(ErrorMessage = "dept name is required")]
        public string? dept_name { get; set; }
       
    }
}
