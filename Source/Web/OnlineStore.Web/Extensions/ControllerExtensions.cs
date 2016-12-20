using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static string ToControllerName(this string fullControllerClassName)
        {
            return fullControllerClassName.Replace("Controller", "");
        }
    }
}