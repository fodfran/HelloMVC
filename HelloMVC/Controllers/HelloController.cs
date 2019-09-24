using Microsoft.AspNetCore.Mvc;

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
                "<input type='text' name='name' />" +
                "<select name = 'language'>" +
                "< option value = 'Hello' > English </ option >" +
                "< option value = 'Hola' > Spanish </ option >" +
                "< option value = 'Bonjour' > French </ option >" +
                "< option value = '今日は' > Japanese </ option >" +
                "< option value = '안녕하세요' > Korean </ option >" +
                "</ select > " +
                "<input type='submit' value='Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
            //return Redirect("/Hello/Goodbye");
        }

        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "SHINee")
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
        //[Route("/Hello/Aloha")]
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }
}
