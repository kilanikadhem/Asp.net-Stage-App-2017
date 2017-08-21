using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Models
{
    public class Question
    {
        public int id { get; set;  }
        public String quest { get; set;  }
        public String type { get; set; }
        public ICollection<repense> repenses { get; set; }
    }
}
