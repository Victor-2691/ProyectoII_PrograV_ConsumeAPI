
using System;
using System.Collections.Generic;
using System.Globalization;
using ConsumeApis;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace CursosC
{

    public partial class Curso
    {

        public const string BaseUrl = "http://localhost:64612/api/Cursoes";

        [JsonProperty("Codigo_Curso")]
        public string Codigo_Curso { get; set; }

        [JsonProperty("Nombre_Curso")]
        public string Nombre_Curso { get; set; }

        [JsonProperty("Codigo_Carrera")]
        public string Codigo_Carrera { get; set; }


    }


    public partial class Curso
    {
        public static List<Curso> FromJson(string json) => JsonConvert.DeserializeObject<List<Curso>>(json, pruebaconsumeAPI.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Curso self) => JsonConvert.SerializeObject(self, pruebaconsumeAPI.Converter.Settings);
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



