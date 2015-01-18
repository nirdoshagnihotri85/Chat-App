using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LetsChat.Settings
{
    public class SystemSettings
    {
        public static string ApiPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiPath"];
            }
        }
    }
}