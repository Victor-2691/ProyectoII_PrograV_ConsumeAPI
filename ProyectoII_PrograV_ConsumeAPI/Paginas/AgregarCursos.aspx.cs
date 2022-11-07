using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursosC;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class AgregarCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_GuardarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
               Api_Cursos api_Cursos = new Api_Cursos();

                Curso C = new Curso()
                {

                    Codigo_Curso = Codigo_Curso.Value,
                    Nombre_Curso = Nombre_Curso.Value,
                    Codigo_Carrera = Codigo_Carrera.Value
                };

                api_Cursos.NuevoCursos(C);
                string codigoresulta = api_Cursos.NuevoCursos(C);
             /*    switch (codigoresulta)
                   {
                       case "1":
                           string msg = "La Carrera se agrego con exito";
                           ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert",
                          "alert('" + msg + "');window.location ='Cursos.aspx';", true);
                           Response.Redirect("Cursos.aspx");
                           Codigo_Curso.Value = "";
                           Nombre_Curso.Value = "";
                           Codigo_Carrera.Value = "";

                           break;
                       case "2":
                           ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert",
                          "alert('" + "La Carrera que esta intentando ingresar ya fue registrada" + "');window.location ='Default.aspx';", true);
                           Response.Redirect("Cursos.aspx");
                           break;

                       default:
                           ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + codigoresulta + "');window.location ='Cursos.aspx';", true);
                           Response.Redirect("Cursos.aspx");
                           break;
                   }*/

                if (api_Cursos.NuevoCursos(C)=="201")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "El Curso fue registrado Exitosamente" + "');window.location ='Default.aspx';", true);

                }
                if (api_Cursos.NuevoCursos(C) == "409")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "Conflicto con el Curso que desea ingresar" + "');window.location ='Default.aspx';", true);

                }
                if (api_Cursos.NuevoCursos(C) == "500")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "Error con el Servidor intente de nuevo más tarde" + "');window.location ='Default.aspx';", true);

                }
                if (api_Cursos.NuevoCursos(C) == "404")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "Codigo de Carrera erróneo, intente con unna carrera que exista" + "');window.location ='Default.aspx';", true);

                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "');window.location ='Cursos.aspx';", true);

            }


        }

       
        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx"); 
        }
    }
}