using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Naviam.DataAnalyzer.UI.Controllers.Models
{
    public abstract class VewModelBase
    {
        public string ApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebApiRootUrl"];
            }
        }
    }
}