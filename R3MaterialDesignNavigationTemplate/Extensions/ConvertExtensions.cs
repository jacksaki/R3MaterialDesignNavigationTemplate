using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace R3MaterialDesignNavigationTemplate.Extensions
{
    public static class ConvertExtensions
    {
        public static string? ToHtmlColor(this Color? value)
        {
            if (value is null)
            {
                return null;
            }

            static string lowerHexString(int i) => i.ToString("X2").ToLower();
            var hex = lowerHexString(value.Value.R) +
                      lowerHexString(value.Value.G) +
                      lowerHexString(value.Value.B);
            return "#" + hex;
        }

        public static Color? ToColor(this string code)
        {
            try
            {
                return (Color)ColorConverter.ConvertFromString(code);
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
