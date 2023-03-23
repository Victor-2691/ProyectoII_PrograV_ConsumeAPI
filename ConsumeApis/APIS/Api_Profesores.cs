using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsumeApis.Clases;
using pruebaconsumeAPI;

namespace ConsumeApis.APIS
{

    public class Api_Profesores
    {
        private const string BASE_URL = "http://www.apisprematricula.somee.com/api/Profesores";



        public List<profesorConsulta> ListarTodosProfesor()
        {
            try
            {
                List<profesorConsulta> E2 = new List<profesorConsulta>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/ConsultaProfesores";
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
                        E2 = profesorConsulta.FromJson(resultSrt);
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

        public List<profesorConsulta> BuscarProfesorNombre(string id)
        {
            try
            {
                List<profesorConsulta> E2 = new List<profesorConsulta>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/ProfesorxNombre";
                        return await estudian.GetAsync(url +"?id="+ id);
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
                        E2 = profesorConsulta.FromJson(resultSrt);
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
        public List<profesorConsulta> BuscarProfesorID(string id, string tipoId)
        {
            try
            {
                List<profesorConsulta> E2 = new List<profesorConsulta>();
                using (var estudian = new HttpClient())
                {

                    var task1 = Task.Run(async () =>
                    {
                        string url = BASE_URL + "/ProfesorID";
                        return await estudian.GetAsync(url +"?id="+ id + "-" + tipoId);
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
                        E2 = profesorConsulta.FromJson(resultSrt);
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

        public string InsertarProfesor(profesor e)
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
                        string url = BASE_URL + "/CrearProfesor";
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
                    if (Message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        return "500";

                    }



                }

            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }

        public string ActulizarEstudiante(profesorConsulta e)
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

        public string EliminaEstudiante(string id)
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
