﻿using System.Web;
using System.Web.Mvc;

namespace TIPS.Pricing
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}