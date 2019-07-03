using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherMaster
{
    public class Info : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n\t");
            sb.Append("alert('Hello Injection');");
            sb.Append("\n");
            ViewBag.javascript = sb;
            return View();
        }

       
        
    }
}
