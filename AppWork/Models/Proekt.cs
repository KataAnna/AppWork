using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWork.Models
{
    public class Proekt
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Number of Employees needed")]
        public int NumberOfWorkers { get; set; }



        public ICollection<Manager> Managers { get; set; }
    }
}
