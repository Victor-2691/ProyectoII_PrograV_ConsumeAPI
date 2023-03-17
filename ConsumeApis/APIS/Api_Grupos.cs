using claseconsume;
using grupos_consulta;
using grupos_insertar;
using periodos;
using pruebaconsumeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApis.APIS
{
    public class Api_Grupos
    {
        private const string BASE_URL = "http://www.apisprematricula.somee.com/api/Grupos";


        public List<Gruposconsulta> ListarGrupos()
        {
            try
            {
                List<Gruposconsulta> E2 = new List<Gruposconsulta>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/ListaGrupos";
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
                        E2 = Gruposconsulta.FromJson(resultSrt);
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


        public string insetarGrupos(Grupo e)
        {
         
            String retorno = "";
            try
            {
                string json = e.ToJson();
                using (var estudian = new HttpClient())
                {
                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/CrearGrupo";
                        return await estudian.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")
                        );

                    }
                        );
                    HttpResponseMessage Message = task1.Result;
                    if (Message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        retorno = "201";

                    }

                    if (Message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        retorno = "409";
                    }

                    if (Message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        retorno = "500";
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

        public string ActulizaGrupo(Grupo e)
        {
            try
            {
                string json = e.ToJson();
                var cliente = new HttpClient();
                var tarea = Task.Run
                (
                   async () =>
                   {
                       return await cliente.PutAsync(BASE_URL, new StringContent(json, Encoding.UTF8, "application/json"));
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


        public string EliminaGrupo(string id)
        {
            try
            {

                var cliente = new HttpClient();
                var tarea = Task.Run

                    (
                   async () =>
                   {
                       return await cliente.DeleteAsync(BASE_URL + "?id=" + id);
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


    }
}
