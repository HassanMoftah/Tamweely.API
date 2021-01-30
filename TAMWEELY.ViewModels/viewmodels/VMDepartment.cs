using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TAMWEELY.ViewModels.viewmodels
{
    public class VMDepartment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
    }
}
