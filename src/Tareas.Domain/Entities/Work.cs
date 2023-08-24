using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Domain.Entities
{
    public class Work : BaseEntity
    {
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Complete { get; set; }
        public Category Category { get; set; }
    }
}
