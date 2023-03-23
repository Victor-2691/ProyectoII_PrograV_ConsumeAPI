﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using grupos_insertar;
//
//    var grupo = Grupo.FromJson(jsonString);

namespace grupos_insertar
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Grupo
    {
        [JsonProperty("codigocurso")]
        public string Codigocurso { get; set; }

        [JsonProperty("tipo_ID")]
        public string TipoId { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("anno")]
        public int Anno { get; set; }

        [JsonProperty("numeroPeriodo")]
        public int NumeroPeriodo { get; set; }

        [JsonProperty("numerogrupo")]
        public int Numerogrupo { get; set; }

        [JsonProperty("horario")]
        public string Horario { get; set; }
    }

    public partial class Grupo
    {
        public static Grupo FromJson(string json) => JsonConvert.DeserializeObject<Grupo>(json, grupos_insertar.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Grupo self) => JsonConvert.SerializeObject(self, grupos_insertar.Converter.Settings);
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