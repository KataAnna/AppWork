using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWork.Models
{
    public class Programist
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        public ICollection<Manager> Managers { get; set; }
    }
}
