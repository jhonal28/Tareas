using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Description { get; set; }
    }
}
