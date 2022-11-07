using ConsumeApis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CursosC;
using pruebaconsumeAPI;


namespace ConsumeApis.APIS
{
    public class Api_Cursos
    {
        
        private string URL;
        private HttpClient cliente;
        private string codigo;
        public string Codigo { get => codigo; set => codigo = value; }
        public Api_Cursos()
        {
            URL = "http://localhost:64612/api/Cursoes";
            cliente = new HttpClient();
            Codigo = "";
        }
        public List<Curso> ObtenerCursos()
        {
            List<Curso> datos = new List<Curso>();
            var tarea = Task.Run
            (
                 async () =>
                 {
                     return await cliente.GetAsync(URL);
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

                string resultado = tarea2.Result;
                datos = JsonConvert.DeserializeObject<List<Curso>>(resultado);


            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Codigo = "404";

            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Codigo = "500";
            }


            return datos;
        }
        public List<Curso> FltrarCurso(string id)// se filtra por carrera
        {
            List<Curso> datos = new List<Curso>();

            var tarea = Task.Run
             (
                  async () =>
                  {
                      return await cliente.GetAsync(URL + "?id=" + id);
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

                codigo = "200";
                string resultado = tarea2.Result;
                datos = JsonConvert.DeserializeObject<List<Curso>>(resultado);


            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Codigo = "404";

            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Codigo = "500";
            }


            return datos;

        }
        public string NuevoCursos(Curso c)
        {
            string json = c.ToJson();

            var tarea = Task.Run
            (
               async () =>
               {
                   return await cliente.PostAsync(URL, new StringContent(json, Encoding.UTF8, "application/json"));
               }
            );


            HttpResponseMessage mensaje = tarea.Result;

            if (mensaje.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var tarea2 = Task<string>.Run
                (
                    async () =>
                    {
                        return await mensaje.Content.ReadAsStringAsync();
                    }

                );

                return "201";// usuario creado
            }
            else
            {
                if (mensaje.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "409";// conflicto (el usuario ya existe)

                }
                else
                {
                    if (mensaje.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "404";

                    }
                    else
                    {
                        if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            return "500";/*Error interno en el servidor*/

                        }
                        else
                        {
                            return "";

                        }

                    }

                }

            }
        }
        public string ActulizarCurso(string id, Curso c)
        {
            string json = c.ToJson();

            var tarea = Task.Run
            (
               async () =>
               {
                   return await cliente.PutAsync(URL + "?id=" + id, new StringContent(json, Encoding.UTF8, "application/json"));
               }
            );


            /*Obtiene la respuesta de la ap(ok,no content....)*/
            HttpResponseMessage mensaje = tarea.Result;

            if (mensaje.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var tarea2 = Task<string>.Run
                (
                    async () =>
                    {
                        return await mensaje.Content.ReadAsStringAsync();
                    }

                );

                return "204";
            }
            else
            {
                if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return "500";
                }
                else
                {
                    if (mensaje.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "409";
                    }
                    else
                    {
                        return "";

                    }

                }

            }

        }
        public string EliminarCurso(string id)
        {
            var tarea = Task.Run
            (
               async () =>
               {
                   return await cliente.DeleteAsync(URL + "?id=" + id);
               }
            );

            HttpResponseMessage mensaje = tarea.Result;

            if (mensaje.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var tarea2 = Task<string>.Run
                (
                    async () =>
                    {
                        return await mensaje.Content.ReadAsStringAsync();
                    }
                );

                return "204";
            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return "404";

            }

            if (mensaje.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return "500";
            }

            return "";
        }



    }
}