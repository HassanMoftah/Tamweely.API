using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TAMWEELY.ViewModels.viewmodels
{
    public class VMEmployee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Phone(ErrorMessage ="Phone Number Not Valid")]
        [Required]
        public string Phone { get; set; }

        [Required]
        public int JobId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public VMDepartment Department { get; set; }
        public VMJob Job { get; set; }

        public string ImagePath { get; set; }


    }
}
