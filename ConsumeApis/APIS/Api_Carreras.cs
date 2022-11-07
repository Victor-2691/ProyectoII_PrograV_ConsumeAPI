﻿using ConsumeApis.Clases;
using Newtonsoft.Json;
using pruebaconsumeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApis.APIS
{
    public class Api_Carreras
    {
        private const string BaseUrl = "http://localhost:64612/api/Carreras";
        public Api_Carreras()
        {
        }

        public List<Carreras> ConsultaCarreras()
        {
            try
            {
                List<Carreras> carreras = new List<Carreras>();
                using (var carrer = new HttpClient())
                {
                    var Task1 = Task.Run(async () =>
                    {
                        return await carrer.GetAsync(BaseUrl);

                    }
                    );
                    HttpResponseMessage Res = Task1.Result;
                    if (Res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var carreraResponse = Task<string>.Run(async () =>

                        {
                            return await Res.Content.ReadAsStringAsync();

                        }

                        );

                        string resultSrt = carreraResponse.Result;
                        carreras = Carreras.FromJson(resultSrt);
                    }

                    if (Res.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        carreras = null;
                    }
                    return carreras;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string InsertarCarreras(Carreras c)
        {
            //Codigos de retorno del metodo
            // 201 creado : 1
            // 409 conflicto: 2
            // 404 no encontrado hijo: 3
            // BadRequest Retorna mensaje 
            String retorno = "";
            try
            {
                string json = c.ToJson();
                using (var carrer = new HttpClient())
                {
                    var task1 = Task.Run(async () =>
                    {
                        string url = BaseUrl + "/CrearCarrera";
                        return await carrer.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")
                        );

                    }
                        );
                    HttpResponseMessage Message = task1.Result;
                    if (Message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        retorno = "1";

                    }

                    if (Message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        retorno = "2";
                    }
                    if (Message.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await Message.Content.ReadAsStringAsync();
                        });
                        string resultSrt = task2.Result;
                        retorno = resultSrt;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }





    }


}