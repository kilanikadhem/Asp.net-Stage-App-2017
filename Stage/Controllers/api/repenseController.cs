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

    public class repenseController : Controller
    {
        private IStageRepository _sc;
        public repenseController(IStageRepository sc)
        {
            _sc = sc;
        }
        [HttpGet]
        [Route("api/repense/{id?}")]
        public IActionResult GetAllrepenseById(int id)
        {
            return Ok(_sc.getrepenseById(id));
        }

        [HttpGet]
        [Route("api/repense/{quest?}/{form?}")]

        public IActionResult GetrepByquestAndrep(String quest, String form)
        {
            return Ok(_sc.getrepenseByFormAndQuest(form, quest));
        }

        [HttpPost]
        [Route("api/repense/{id?}")]
        public async Task<IActionResult> insertRepAsync(int id, [FromBody]repense r)
        {

            if (ModelState.IsValid)
            {

                _sc.Addr(id, r);
                if (await _sc.SaveChangesAsync())
                {
                    return Created($"api/repense/{r.contenu}", r);
                }
            }
            return BadRequest("failed to save the answer");

        }

        [HttpPut]
        [Route("api/repense/{id?}/{resp?}")]
        public IActionResult updateRespense(int id, String resp)
        {
           
            return Ok(_sc.updateRepense(id, resp));
        }

        [HttpDelete]
        [Route("api/repense/{id?}")]
        public IActionResult DeleteRepense(int id)
        {
            return Ok(_sc.DeleteRepense(id));
        }
        [HttpPut]
        [Route("api/repense/{id?}")]
        public IActionResult incRep(int id)
        {
            return Ok(_sc.incRepens(id));
         
            }
    }
}
