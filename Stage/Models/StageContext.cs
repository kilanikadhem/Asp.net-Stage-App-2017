
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Models
{
    public class StageContext : DbContext
    { 
        private IConfigurationRoot _config;

        public StageContext(IConfigurationRoot config, DbContextOptions option) : base(option)
        {
            _config = config;  
        }

        public DbSet<Formulaires> Formulairess { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<repense> repenses { get; set;  }
        //modification fichier Startup 
        // add in the Const of HomeController

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   //link with each instance of this COntext that is created 
            base.OnConfiguring(optionsBuilder);
            //la connection vers la base  SQL
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:StageContext"]);
        }
    }
}
