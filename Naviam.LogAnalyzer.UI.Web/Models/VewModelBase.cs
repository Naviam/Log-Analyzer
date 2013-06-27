using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Naviam.DataAnalyzer.UI.Web.Models
{
    public abstract class VewModelBase
    {
        protected string ApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebApiRootUrl"];
            }
        }
    }
}