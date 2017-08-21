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

    public class FormulairesController : Controller
    {
        private IStageRepository _sc;

        public FormulairesController(IStageRepository sc)
        {
            _sc = sc;
        }


        [HttpGet]
        [Route("api/Formulaire/getAllFormulaires")]
        public IActionResult GetAllFormulaires()
        {
            try
            {
                var formList = _sc.getAllFormulaires();
                return Ok(formList);

            }
            catch (Exception ex)
            {

            }
            return BadRequest("no connection ");
        }

        [HttpGet]
        [Route("api/Formulaire/getAllFormulairesView")]
        public IActionResult GetAllFormulairesV(String tripName)
        {
            try
            {
                var formList = _sc.getAllFormulairesView();
                return Ok(formList);

            }
            catch (Exception ex)
            {

            }
            return BadRequest("no connection ");
        }
        [HttpGet]
        [Route("api/Formulaire/{id?}")]
        public IActionResult GetFormulaireByID(int id)
        {
            try
            {
                return Ok(_sc.getFormulairesById(id));
            }
            catch (Exception ex)
            {

            }
            return BadRequest("no connection ");
        }

        [HttpGet]
        [Route("api/Formulaire/NF/{name?}")]
        public IActionResult GetFormulaireByName(String name)
        {
            return Ok(_sc.getFormulairesByName(name));
        }


        [HttpPost]
        [Route("api/Formulaire")]
        public async Task<IActionResult> PostFormulairesAsync([FromBody]Formulaires f)
        {

            if (ModelState.IsValid)
            {
                _sc.addF(f);
                if (await _sc.SaveChangesAsync())
                {
                    return Created($"api/Formuliare/{f.sujet}", f);
                }
            }
            return BadRequest("failed to save the trip");

        }

        [HttpPut]
        [Route("api/Formulaire/{id?}/{name?}")]
        public IActionResult UpdateForm(String name, int id)
        {
            Debug.WriteLine(name);
            Debug.WriteLine("*********");
            Debug.WriteLine(id);
            return Ok(_sc.UpdateFormulaires(name, id));


        }

        [HttpPut]
        [Route("api/Formulaire/Date/{id?}/{nbreD?}")]
        public IActionResult UpdateDate(int id, int nbreD)
        {
            Debug.WriteLine("******Controller*******");
            Debug.WriteLine(id);
            Debug.WriteLine(nbreD);
            return Ok(_sc.UpdateDate(id,nbreD));
        }


        [HttpDelete]
        [Route("api/Formulaire/{id?}")]
        public IActionResult DeleteFormuliare(int id)
        {   
            return Ok(_sc.DeleteDate(id));
        }
    }

    }
