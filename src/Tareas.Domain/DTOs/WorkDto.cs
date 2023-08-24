using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Domain.DTOs
{
    public class WorkDto
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Complete { get; set; }
    }
}
