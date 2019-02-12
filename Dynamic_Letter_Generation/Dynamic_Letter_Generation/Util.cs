using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dynamic_Letter_Generation
{
    public class Util
    {
        public static string GetFullImagePath(string imagename)
        {
            string root = HttpContext.Current.Server.MapPath(".");
            string basicImagePath = root + "\\images";
            String basicImageName = imagename;  // This can be retrieved from database dynamically
            String ImageFullPath = basicImagePath + "\\" + basicImageName + ".jpg";
            return ImageFullPath;
        }
    }
}