

namespace ConsumeApis.Clases
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class profesorConsulta
    {
        [JsonProperty("tipo_ID")]
        public string TipoId { get; set; }

        [JsonProperty("Identificacion")]
        public string Identificacion { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("primer_Apellido")]
        public string PrimerApellido { get; set; }

        [JsonProperty("segundo_apellido")]
        public string SegundoApellido { get; set; }

        [JsonProperty("fecha_Nacimiento")]
        public string FechaNacimiento { get; set; }

    

    }
    public partial class profesorConsulta
    {
        public static List<profesorConsulta> FromJson(string json) => JsonConvert.DeserializeObject<List<profesorConsulta>>(json, ConsumeApis.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this profesorConsulta self) => JsonConvert.SerializeObject(self, ConsumeApis.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
