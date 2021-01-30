using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TAMWEELY.DataLayer.Models
{
    public class TbUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
