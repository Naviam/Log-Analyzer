using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Naviam.DataAnalyzer.UI.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
