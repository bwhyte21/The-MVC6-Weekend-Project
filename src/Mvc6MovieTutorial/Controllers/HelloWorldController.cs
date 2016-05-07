using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace Mvc6MovieTutorial.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public string Index(){ return "This is my default action!"; }

        //
        // GET: /HelloWorld/Welcome/
        public string Welcome() { return "This is the Welcome action method, so WELCOME!!"; }


    }
}
