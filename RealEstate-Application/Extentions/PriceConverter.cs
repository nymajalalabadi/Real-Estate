using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Extentions
{
    public static class PriceConverter
    {
        public static string ToToman(this int value) => value.ToString("#,0 تومان");
        public static string ToToman(this double value) => value.ToString("#,0 تومان");
    }

}
