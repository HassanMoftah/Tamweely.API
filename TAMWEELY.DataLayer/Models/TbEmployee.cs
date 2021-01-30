using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TAMWEELY.DataLayer.Models
{
    public class TbEmployee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(max)")]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public TbDepartment Department { get; set; }


        [Required]
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public TbJob Job { get; set; }
    }
}
