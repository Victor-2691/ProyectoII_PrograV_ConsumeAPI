﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace ConsumeApis.APIS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using ConsumeApis;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class profesor
    {


        [JsonProperty("tipo_ID")]
        public string TipoId { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("primerApellido")]
        public string PrimerApellido { get; set; }

        [JsonProperty("SegundoApellido")]
        public string SegundoApellido { get; set; }

        [JsonProperty("FechaNacimiento")]
        public string FechaNacimiento { get; set; }

        [JsonProperty("correoEle")]
        public string CorreoEle { get; set; }

        [JsonProperty("NumerosTelefono")]
        public string NumerosTelefono { get; set; }

    }


    public partial class profesor
    {
        public static List<profesor> FromJson(string json) => JsonConvert.DeserializeObject<List<profesor>>(json, ConsumeApis.APIS.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this profesor self) => JsonConvert.SerializeObject(self, ConsumeApis.APIS.Converter.Settings);
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

