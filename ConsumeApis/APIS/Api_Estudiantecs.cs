using Newtonsoft.Json;
using pruebaconsumeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ConsumeApis.Clases;

namespace ConsumeApis.APIS
{
    public class Api_Estudiantecs
    {
        private const string BASE_URL = "http://localhost:64612/api/Estudiantes";

        public Api_Estudiantecs()
        {
        }

        public List<estudiante2> ConsultaEstudiantes()
        {
            try
            {
                List<estudiante2> E2 = new List<estudiante2>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/todosestudiantes";
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
                        E2 = estudiante2.FromJson(resultSrt);



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

        public string insetarEstudiante(estudiante e)
        {
            //Codigos de retorno del metodo
            // 201 creado : 1
            // 409 conflicto: 2
            // 404 no encontrado hijo: 3
            // BadRequest Retorna mensaje 
            String retorno = "";
            try
            {
                string json = e.ToJson();
                using (var estudian = new HttpClient())
                {
                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/CrearEstudiante";
                        return await estudian.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")
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

        public string ActulizarEstudiante(estudiante2 e)
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

        public string EliminaEstudiante(string  id)
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

            }
            catch (Exception)
            {

                throw;
            }
            return "";

        }
         
    }
 }



