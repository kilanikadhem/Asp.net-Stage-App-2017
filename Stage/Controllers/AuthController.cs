using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage.Controllers
{
    public class AuthController :Controller
    {

        public IActionResult Login()
        {
          
            return View();
        }

    }
}
