﻿using System.Web;
using System.Web.Mvc;

namespace HarvestHelp_PassionProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
