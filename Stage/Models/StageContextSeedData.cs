using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Models
{
    public class StageContextSeedData
    {
        private StageContext _context;

        public StageContextSeedData(StageContext context)
        {
            _context = context;
        }
        //methode that ensure that there's data in DB 
        public async Task EnsureData()
        {
            if (!_context.Formulairess.Any())
            {
                var Dot_F_Emp = new Formulaires
                {
                    sujet = "Dot_it Emp Formulaire test",
                    date_creation = DateTime.UtcNow,
                    nbreParticipant = 0,
                    nbreQuestion = 2,
                    Questions = new List<Question>() {
                       new Question{
                           quest ="depuis quand vous etes a dot it ?" ,
                           type ="btn Radio",
                           repenses= new List<repense>()
                           {
                               new repense{


                                     contenu ="plus que 1 ans ",
                                     nbreChoisie=0
                               },
                               new repense{


                                     contenu ="moins que 1 ans ",
                                     nbreChoisie=0
                               }

                           }
                       },
                       new Question{
                           quest ="rythme ou rendement ?" ,
                           type ="btn Radio",
                           repenses= new List<repense>()
                           {
                               new repense{


                                     contenu ="bien  ",
                                     nbreChoisie=0
                               },
                               new repense{


                                     contenu ="moyen ",
                                     nbreChoisie=0
                               }

                           }
                       }


                     }

                       
                  
                 };

                _context.Formulairess.Add(Dot_F_Emp);
                _context.Questions.AddRange(Dot_F_Emp.Questions);

               
                   

                var Dot_F_stg = new Formulaires
                {
                    sujet = "Dot_it Stg Formulaire test",
                    date_creation = DateTime.UtcNow,
                    nbreParticipant = 0,
                    nbreQuestion = 2,
                   
                    Questions = new List<Question>() {
                       new Question{
                           quest ="quelle type de stage ?" ,
                           type ="btn Radio",
                           repenses= new List<repense>()
                           {
                               new repense{


                                     contenu ="satge d'ete ",
                                     nbreChoisie=0
                               },
                               new repense{


                                     contenu ="stage PFE ",
                                     nbreChoisie=0
                               }

                           }
                       },
                       new Question{
                           quest ="envie de retourner  ?" ,
                           type ="btn Radio",
                           repenses= new List<repense>()
                           {
                               new repense{


                                     contenu ="oui",
                                     nbreChoisie=0
                               },
                               new repense{


                                     contenu ="Non",
                                     nbreChoisie=0
                               }

                           }
                       }


                     }
                };
                _context.Formulairess.Add(Dot_F_stg);
                _context.Questions.AddRange(Dot_F_stg.Questions);
                await _context.SaveChangesAsync();
            }

        }
        }
}
