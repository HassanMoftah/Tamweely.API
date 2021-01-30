using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TAMWEELY.DataLayer.Models
{
    public class TbDepartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }


        public virtual List<TbEmployee> Employees { get; set; }
    }
}
