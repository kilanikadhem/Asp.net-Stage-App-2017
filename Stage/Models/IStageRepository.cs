using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stage.Models
{
    public interface IStageRepository
    {
        IEnumerable<Formulaires> getAllFormulaires();
        IEnumerable<Question> getAllFQuestions();
        IEnumerable<repense> getAllrepense();
        IEnumerable<Formulaires> getAllFormulairesView();
        ICollection<Question> getrepenseById();
        ICollection<Formulaires> getQuestionById();
        IEnumerable<Question> getAllQuestions(string nameF);
        IEnumerable<Question> getAllQuestionsView(String nameF);
        IEnumerable<Question> deleteQuestion(int i);
        IEnumerable<Formulaires> UpdateFormulaires(String nameF, int i);
        IEnumerable<Formulaires> UpdateDate(int id, int nbreD);
        IEnumerable<Formulaires> DeleteDate(int id);
        Formulaires getFormulairesById(int i);
        Question getquestionById(int i);
        Question updateQuestion(int i, String quest);
        repense getrepenseById(int i);
        repense updateRepense(int i, String resp);
        IEnumerable<repense> DeleteRepense(int i);
        ICollection<repense> getrepenseByFormAndQuest(String form, String quest);
        Formulaires getFormulairesByName(String name);
        int getFormulairesCount();
        int getQuestionsCount();
        int getrespenseCount();
        void addF(Formulaires f);
        void Addq(int i, Question q);
        void Addr(int id, repense r);
        Task<bool> SaveChangesAsync();
        
    }
}