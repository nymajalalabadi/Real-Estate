using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Utils
{
    public static class PathExtensions
    {
        #region Estate

        public static string EstateOrgin = "/image/Estates/orgin/";
        public static string EstateOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Estates/orgin/");

        public static string EstateThumb = "/image/Estates/thumb/";
        public static string EstateThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Estates/thumb/");

        #endregion
    }
}
