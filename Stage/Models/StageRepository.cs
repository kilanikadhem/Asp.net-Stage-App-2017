using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Models
{
    public class StageRepository : IStageRepository
    {
        private StageContext _sc;

        public StageRepository(StageContext sc)
        {
            _sc = sc;
        }
         
        public IEnumerable<Formulaires> getAllFormulaires()
        {
            return _sc.Formulairess.ToList();
        }
        public IEnumerable<Question> getAllFQuestions()
        {
            return _sc.Questions.ToList();
        }

        public IEnumerable<repense> getAllrepense()
        {
         

            return _sc.repenses.ToList();
        }

        public int getFormulairesCount()
        {
            return _sc.Formulairess.ToList().Count;
        }

        public int getQuestionsCount()
        {
            return _sc.repenses.ToList().Count;
        }

        public int getrespenseCount()
        {
            return _sc.repenses.ToList().Count;
        }

        public ICollection<Formulaires> getQuestionById()
        {   //include d'autres entity qui sont des proprietes pour trips
            //where == filtre 
          
            return  (ICollection<Formulaires>)_sc.Formulairess.Include(t=>t.Questions).ToList();

        }

       public ICollection<Question> getrepenseById()
        {

            return (ICollection<Question>)_sc.Questions.Include(q => q.repenses).ToList();
        }

        public Formulaires getFormulairesById(int i)
        {
            return _sc.Formulairess.Include(f => f.Questions)
                  .Where(f => f.id == i).FirstOrDefault();
            

        }
        public Formulaires getFormulairesByName(String name)
        {
            return _sc.Formulairess.Include(f => f.Questions)
                  .Where(f => f.sujet.Contains(name)).FirstOrDefault();


        }

        public IEnumerable<Formulaires> getAllFormulairesView()
        {
            var dataF = this.getQuestionById();
            var dataQ = this.getrepenseById();
            foreach (var itemf in dataF)
            {
                foreach (var item in itemf.Questions)
                {

                    foreach (var itemq in dataQ)
                    {
                        if (item.id == itemq.id)
                        {
                            item.repenses = itemq.repenses;
                        }
                    }
                }
            }
            return dataF;
        }

        public IEnumerable<Question> getAllQuestionsView(String nameF)
        {   //list complete des questions avec les respences
            var data = _sc.Questions.Include(q => q.repenses);
            var dataF = _sc.Formulairess.Include(f => f.Questions)
                  .Where(f => f.sujet.Contains(nameF)).FirstOrDefault();
            //dataQ tous les questions de formulaires en param 
            var dataQ = dataF.Questions;
            foreach( var item in data)
            {
               foreach(var item1 in dataQ)
                {
                    if (item.id == item1.id)
                    {
                        item1.repenses = item.repenses;
                    }
                }
            }

            return dataQ;
        }

        public IEnumerable<Question> getAllQuestions(string nameF)
        {
            var data = _sc.Formulairess.Include(f => f.Questions)
                  .Where(f => f.sujet.Contains(nameF)).FirstOrDefault();
            var dataQ = data.Questions;
            return dataQ;

        }

        public Question getquestionById(int i)
        {

            return (Question)_sc.Questions.Include(q => q.repenses).Where(q =>q.id==i).FirstOrDefault();

        }

        public repense getrepenseById(int i)
        {

            return (repense)_sc.repenses.Where(r => r.id == i).FirstOrDefault();

        }

        public ICollection<repense> getrepenseByFormAndQuest(String form,String quest)
        {
            var data = this.getAllFormulairesView();
            foreach(var item in data) {
                if (item.sujet.Contains(form))
                {
                    foreach(var item1 in item.Questions)
                    {
                        if (item1.quest.Contains(quest))
                        {
                            return item1.repenses.ToList();
                        }
                    }
                }
            }
            return null;

        }

        public void addF(Formulaires f)
        {
            f.date_creation = DateTime.UtcNow.AddDays(-10);
            f.date_fin = DateTime.UtcNow;
            f.nbreParticipant = 0;
            f.nbreQuestion = f.Questions.Count;
           _sc.Formulairess.Add(f);
            _sc.Questions.AddRange(f.Questions);
            
        }

        public IEnumerable<Formulaires> UpdateFormulaires(String nameF,int i)
        {   
            Debug.WriteLine(i);
            Debug.WriteLine(nameF);
            var Form = (from form in _sc.Formulairess
                       where form.id == i
                       select form).SingleOrDefault();
            if(Form != null)
            {
                Form.sujet = nameF;
            }
            _sc.SaveChanges();
            return getAllFormulairesView();
        }

        public IEnumerable<Formulaires> UpdateDate(int id,int nbreD)
        {
            Debug.WriteLine("******repository*******");
            Debug.WriteLine(id);
            Debug.WriteLine(nbreD);

            var Form = (from form in _sc.Formulairess
                        where form.id == id
                        select form).SingleOrDefault();
            if (Form != null)
            {
                Form.date_fin = Form.date_fin.AddDays(nbreD);
            }
            _sc.SaveChanges();
            return getAllFormulairesView();
        }


        public IEnumerable<Formulaires> DeleteDate(int id)
        {
           
                var Form = (from form in _sc.Formulairess
                           where form.id ==  id
                           select form).Include(f => f.Questions).SingleOrDefault();
            if(Form.Questions != null) { 
                foreach(var q in Form.Questions)
                {
                    var Quest = (from quest in _sc.Questions
                                where quest.id == q.id
                                select quest).Include(f => f.repenses).SingleOrDefault();
                    if (Quest.repenses != null)
                    {   
                        foreach(var resp in q.repenses)
                        {
                            _sc.repenses.Remove(resp);
                        }
                    }
                    _sc.Questions.Remove(q);
                }

                _sc.Formulairess.Remove(Form);
            }
              _sc.SaveChanges();
                return getAllFormulairesView();
          
        }

        public repense updateRepense(int i ,String resp)
        {
            var Rep = (from rep in _sc.repenses
                         where rep.id == i
                         select rep).SingleOrDefault();
           
            if ( Rep != null)
            {
              
                Rep.contenu = resp;
            }
            _sc.SaveChanges();

            return getrepenseById(i);
        }

        public IEnumerable<repense> DeleteRepense(int i)
        {
            var Rep = (from rep in _sc.repenses
                       where rep.id == i
                       select rep).SingleOrDefault();
            if(Rep != null)
            {
                _sc.repenses.Remove(Rep);
            }
            _sc.SaveChanges();

            return getAllrepense(); }

        public Question updateQuestion(int i, String quest)
        {
            var Q = (from q in _sc.Questions
                       where q.id == i
                       select q).SingleOrDefault();
   
            if (Q != null)
            {
               
                Q.quest = quest;
            }
            _sc.SaveChanges();

            return getquestionById(i);
        }

        public IEnumerable<Question> deleteQuestion(int i)
        {
            var Q = (from q in _sc.Questions
                     where q.id == i
                     select q).Include(q => q.repenses).SingleOrDefault();

            if (Q != null)
            {
                 foreach(var r in Q.repenses)
                {
                    _sc.repenses.Remove(r);
                }
                _sc.Questions.Remove(Q);
            }
            _sc.SaveChanges();

            return getAllFQuestions();

        }
       

        public async Task<bool> SaveChangesAsync()
        {
            return (await _sc.SaveChangesAsync()) > 0;
        }

        public void Addq(int i, Question q)
        {
            
            var Form = (from f in _sc.Formulairess
                            where f.id == i
                            select f).Include(f =>f.Questions).SingleOrDefault();
         
           // add Question to our Formulaire 
            Form.Questions.Add(q);
              
            //add to DB AUtomatique
            _sc.Questions.Add(q);
             
          
        }

        public void Addr(int id, repense r)
        {
           
            var Quest = (from q in _sc.Questions
                        where q.id == id
                        select q).Include(q => q.repenses).SingleOrDefault();
            
            Debug.WriteLine("kkkkkkkkkkk");
            Debug.WriteLine(Quest.quest);

            Quest.repenses.Add(r);
            foreach(var qu in Quest.repenses)
            {
                Debug.WriteLine("kkkkkkkkkkk");
                Debug.WriteLine(qu.contenu);
            }
            _sc.repenses.Add(r);
        }

        public Formulaires incRepens(int id)
        {
            var Allf = getAllFormulairesView();
            foreach (var Form in Allf)
            {
                foreach (var Quest in Form.Questions)
                {
                    foreach (var rep in Quest.repenses)
                    {
                        if (rep.id == id)
                        {
                            rep.nbreChoisie += 1;
                            Form.nbreParticipant += 1;
                            _sc.SaveChanges();
                            return Form;
                        }
                    }
                }
            }
            return null;
        }
    }
}

// 1) creer l interface
// 2) ajouter au startup
