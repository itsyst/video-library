using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.ViewModel
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
