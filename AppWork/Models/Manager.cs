using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWork.Models
{
    public class Manager
    {
        public int ID { get; set; }
        public int ProektId { get; set; } // project id
        public Proekt Proekt { get; set; } // project


        public int ProgramistId { get; set; } // programmers id
        public Programist Programist { get; set; } // Programme
    }
}
