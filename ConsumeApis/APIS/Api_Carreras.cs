using ConsumeApis.Clases;
using Newtonsoft.Json;
using pruebaconsumeAPI;
using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CarreraInsertar;


namespace ConsumeApis.APIS
{
    public class Api_Carreras
    {
        private const string BaseUrl = "http://localhost:64612/api/Carreras";
        public Api_Carreras()
        {
        }

        public List<carrera> ConsultaCarreras()
        {
            try
            {
                List<carrera> E2 = new List<carrera>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BaseUrl + "/ConsultaCarreras";
                        return await estudian.GetAsync(url);
                    }
                    );
                    HttpResponseMessage Message = task1.Result;
                    if (Message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await Message.Content.ReadAsStringAsync();
                        });
                        string resultSrt = task2.Result;
                        E2 = carrera.FromJson(resultSrt);
                    }

                    if (Message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        E2 = null;
                    }
                    return E2;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public string InsertarCarreras(carrerainsertar c)
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


        public string EliminaCarrera(string id)
        {
            try
            {

                var cliente = new HttpClient();
                var tarea = Task.Run

                    (
                   async () =>
                   {
                       return await cliente.DeleteAsync(BaseUrl + "?id=" + id);
                   }
                );

                HttpResponseMessage mensaje = tarea.Result;

                if (mensaje.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var tarea2 = Task<string>.Run
                    (
                        async () =>
                        {
                            return await mensaje.Content.ReadAsStringAsync();
                        }
                    );

                    return "200";
                }

                if (mensaje.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return "404";

                }
                if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return "500";

                }

            }
            catch (Exception)
            {

                throw;
            }
            return "";

        }

        public string ActulizarCarrera(carrerainsertar C)
        {
            try
            {
                string json = C.ToJson();
                var cliente = new HttpClient();
                var tarea = Task.Run
                (
                   async () =>
                   {
                       return await cliente.PutAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                   }
                );

                HttpResponseMessage Message = tarea.Result;

                if (Message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var tarea2 = Task<string>.Run
                    (
                        async () =>
                        {
                            return await Message.Content.ReadAsStringAsync();
                        }

                    );

                    return "200";
                }

                if (Message.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return "404";
                }

                if (Message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return "500";

                }

                if (Message.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await Message.Content.ReadAsStringAsync();
                    });
                    string resultSrt = task2.Result;
                    return resultSrt;
                }

                return "";


            }
            catch (Exception)
            {

                throw;
            }
        }



    }


}
