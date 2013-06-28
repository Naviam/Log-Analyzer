using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Naviam.DataAnalyzer.UI.Controllers.Models;

namespace Naviam.DataAnalyzer.UI.Controllers
{
    public class MemberController:Controller
    {
        public ActionResult Dashboard()
        {
            return this.View(new MemberDashboardViewModel());
        }

        public ActionResult NewDataSource()
        {
            return this.View();
        }
    }
}
