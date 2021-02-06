using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using static FontAwesome5.Generator.FontAwesomeManager;

namespace FontAwesome5.Generator
{
    public enum EStyles
    {
        Solid,
        Regular,
        Brands,
        Light,
        Duotone
    }

    public class FontAwesomeManager
    {
        private static readonly Regex REG_PROP = new Regex(@"\([^)]*\)");

        public FontAwesomeManager(string iconsJson)
        {
            Icons = JsonConvert.DeserializeObject<Dictionary<string, Icon>>(File.ReadAllText(iconsJson), new JsonSerializerSettings()
            {
                Converters = { new SvgConverter() }
            });
        }

        public string Convert(string text)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            var stringBuilder = new StringBuilder(textInfo.ToTitleCase(text.Replace("-", " ")));

            stringBuilder
                .Replace("-", string.Empty).Replace("/", "_")
                .Replace(" ", string.Empty).Replace(".", string.Empty)
                .Replace("'", string.Empty);

            var matches = REG_PROP.Matches(stringBuilder.ToString());
            stringBuilder = new StringBuilder(REG_PROP.Replace(stringBuilder.ToString(), string.Empty));
            var hasMatch = false;

            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                if (match.Value.IndexOf("Hand", StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    hasMatch = true;
                    break;
                }
            }

            if (hasMatch)
            {
                stringBuilder.Insert(0, "Hand");
            }

            if (char.IsDigit(stringBuilder[0]))
                stringBuilder.Insert(0, '_');

            return stringBuilder.ToString();
        }

        public Dictionary<string, Icon> Icons
        {
            get; set;
        }

        public class Icon
        {
            public string label { get; set; }
            public string unicode { get; set; }
            public List<string> styles { get; set; }
            public Dictionary<string, SVG> svg { get; set; }
        }

        public class SVG
        {
            public string[] viewBox { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string raw { get; set; }
        }

        public class SvgSimple: SVG
        {
            public string path { get; set; }
        }

        public class SvgDuotone: SVG
        {
            public string[] path { get; set; }
        }


        public class SvgConverter : JsonConverter<SVG>
        {

            public override SVG ReadJson(JsonReader reader, Type objectType, SVG existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var jo = JObject.Load(reader);

                SVG svg = null;

                if (jo["path"].Type == JTokenType.String)
                {
                    svg = jo.ToObject<SvgSimple>();
                }
                else if (jo["path"].Type == JTokenType.Array)
                {
                    svg = jo.ToObject<SvgDuotone>();
                }
                
                return svg;
            }

            public override void WriteJson(JsonWriter writer, SVG value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
