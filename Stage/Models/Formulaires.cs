using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Models
{
    public class Formulaires
    {
        public int id { get; set; }
        public String sujet { get; set;  }
        public DateTime date_creation { get; set;  }
        public DateTime date_fin { get; set;  }
        public int nbreParticipant { get; set;  }
        public int nbreQuestion { get; set;  }
        public  ICollection<Question> Questions { get; set; }


    }
}
