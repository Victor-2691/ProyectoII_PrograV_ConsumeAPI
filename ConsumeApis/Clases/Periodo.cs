﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using periodos;
//
//    var periodo = Periodo.FromJson(jsonString);

namespace periodos
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Periodo
    {
        [JsonProperty("anno")]
        public int Anno { get; set; }

        [JsonProperty("numeroPeriodo")]
        public int NumeroPeriodo { get; set; }

        [JsonProperty("fechaInicio")]
        public string FechaInicio { get; set; }

        [JsonProperty("fechafinal")]
        public string Fechafinal { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }
    }

    public partial class Periodo
    {
        public static Periodo FromJson(string json) => JsonConvert.DeserializeObject<Periodo>(json, periodos.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Periodo self) => JsonConvert.SerializeObject(self, periodos.Converter.Settings);
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
