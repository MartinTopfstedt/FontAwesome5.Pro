using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FontAwesome5
{
    /// <summary>
    /// Provides FontFamilies and Typefaces of FontAwesome5.
    /// </summary>
    public static class Fonts
    {
        /// <summary>
        /// FontAwesome5 Regular FontFamily
        /// </summary>
        public static readonly FontFamily RegularFontFamily = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Pro Regular");
        /// <summary>
        /// FontAwesome5 Solid FontFamily
        /// </summary>
        public static readonly FontFamily SolidFontFamily = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Pro Solid");
        /// <summary>
        /// FontAwesome5 Brands FontFamily
        /// </summary>
        public static readonly FontFamily BrandsFontFamily = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Brands Regular");
        /// <summary>
        /// FontAwesome5 Light FontFamily
        /// </summary>
        public static readonly FontFamily LightFontFamily = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Pro Light");
        /// <summary>
        /// FontAwesome5 Duotone FontFamily
        /// </summary>
        public static readonly FontFamily DuotoneFontFamily = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Duotone Regular");

        /// <summary>
        /// FontAwesome5 Regular Typeface
        /// </summary>
        public static readonly Typeface RegularTypeface = new Typeface(RegularFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        /// <summary>
        /// FontAwesome5 Solid Typeface
        /// </summary>
        public static readonly Typeface SolidTypeface = new Typeface(SolidFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        /// <summary>
        /// FontAwesome5 Brands Typeface
        /// </summary>
        public static readonly Typeface BrandsTypeface = new Typeface(BrandsFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        /// <summary>
        /// FontAwesome5 Light Typeface
        /// </summary>
        public static readonly Typeface LightTypeface = new Typeface(LightFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        /// <summary>
        /// FontAwesome5 Duotone Typeface
        /// </summary>
        public static readonly Typeface DuotoneTypeface = new Typeface(DuotoneFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
    }
}
