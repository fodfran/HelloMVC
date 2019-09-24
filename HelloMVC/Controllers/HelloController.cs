using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'> " +
                "<input type='text' name='name'/>" +
                "<select name = 'language'>" +
                "<option value = 'Hello' > English </option>" +
                "<option value = 'Hola' > Spanish </option>" +
                "<option value = 'Bonjour' > French </option>" +
                "<option value = 'Konnichiwa' > Japanese </option>" +
                "<option value = 'Annyeonghaseyo' > Korean </option>" +
                "</select> " +
                "<input type='submit' value='Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
            //return Redirect("/Hello/Goodbye");
        }

        static int counter;
        [Route("/Hello")]
        [HttpPost]
        public IActionResult CreateMessage(string name, string language)
        {
            
            if (Request.Cookies["counter"] == null)
            {
                counter = 1;
            }
            else
            {
                counter = int.Parse(Request.Cookies["counter"]);
                counter++;
            }
            Response.Cookies.Append("counter", counter.ToString());

            return Content(string.Format("<h1>{0} {1}</h1>\nGreetings: {2}", language, name, counter.ToString()), "text/html");
        }
        
        //[Route("/Hello")]
        //[HttpPost]
        public IActionResult Display(string name)
        {
            /*if (string.IsNullOrEmpty(name))
            {
                name = "SHINee";
            }*/
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        // Handle request to /Hello/NAME (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");

        }

        // /Hello/Goodbye
        // alter the route to this controller to be: /Hello/Aloha
        [Route("/Hello/Aloha")]
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }
}
