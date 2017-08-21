using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.ViewModels
{
    public class RepenseViewModel
    {   [Required]
        [StringLength(100, MinimumLength = 5)]
        public String contenu { get; set; }

        public int nbreChoisie { get; set; }
    }
}
