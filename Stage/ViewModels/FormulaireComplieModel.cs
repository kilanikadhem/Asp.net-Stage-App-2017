﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.ViewModels
{
    public class FormulaireComplieModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public String sujet { get; set; }
        [Required]
        public DateTime date_creation { get; set; } = DateTime.UtcNow;
        public DateTime date_fin { get; set; } = DateTime.UtcNow.AddDays(15);
        
    }
}
