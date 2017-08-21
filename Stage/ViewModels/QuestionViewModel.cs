using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.ViewModels
{
    public class QuestionViewModel
    { 
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public String quest { get; set; }

        [Required]
        public String type { get; set; }
    }
}
