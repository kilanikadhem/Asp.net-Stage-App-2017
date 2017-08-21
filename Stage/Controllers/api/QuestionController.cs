using Microsoft.AspNetCore.Mvc;
using Stage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Controllers.api
{

    public class QuestionController : Controller
    {
        private IStageRepository _sc;

        public QuestionController(IStageRepository sc)
        {
            _sc = sc;
        }
        [HttpGet]
        [Route("api/Formulaire/{formulaireName?}/Questions")]
        public IActionResult GetAllQuestions(String FormulaireName)
        {
            return Ok(_sc.getAllQuestionsView(FormulaireName));

        }
        [HttpGet]
        [Route("api/Formulaire/Questions/{id?}")]
        public IActionResult GetAllQuestions(int id)
        {
            return Ok(_sc.getquestionById(id));
        }

        [HttpPut]
        [Route("api/Formulaire/Question/{id?}/{quest?}")]
        public IActionResult UpdateQuestion(int id, String quest)
        {
            return Ok(_sc.updateQuestion(id, quest));
        }

        [HttpPost]
        [Route("api/Formulaire/Questions/{id?}")]
        public async Task<IActionResult> InsertQuestionAsync(int id, [FromBody]Question q)
        {
           
            if (ModelState.IsValid)
            {
                
                _sc.Addq(id, q);
                if (await _sc.SaveChangesAsync())
                {
                    return Created($"api/Formulaire/Questions/{q.quest}",q);
                }
            }
            return BadRequest("failed to save the trip");
        }

        [HttpDelete]
        [Route("api/Formulaire/Question/{id?}")]
        public IActionResult DeleteQuestion(int id)
        {
            return Ok(_sc.deleteQuestion(id));
        }

       

    }
        }
