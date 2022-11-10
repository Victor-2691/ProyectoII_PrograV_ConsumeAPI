﻿using ConsumeApis.APIS;
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
               switch (codigoresulta)
                   {
                       case "210":
                           ScriptManager.RegisterStartupScript(this, GetType(),
                                        "alert", "alert('" + "El curso se creo con exito" + "')", true);

                           break;
                       case "409":
                           ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El curso ya se encuentra registrado en la BD" + "')", true);
                           break;


                    case "404":
                           ScriptManager.RegisterStartupScript(this, GetType(),
                                   "alert", "alert('" + "La carrera que ingreso no existe, por favor modifiquela" + "')", true);
                           break;
                   }*/

                    case "500":
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                   "alert", "alert('" + "Error interno servidor" + "')", true);
                        break;

                }
                if (api_Cursos.NuevoCursos(C) == "409")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "Conflicto con el Curso que desea ingresar" + "');window.location ='Default.aspx';", true);

                    default:
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                        "alert", "alert('" + codigoresulta + "')", true);
                           break;
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
                                                   "alert", "alert('" + ex.Message + "')", true);

            }


        }

       
        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx"); 
        }
    }
}