﻿using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                Cursos NuevaC = new Cursos()
                {
                    Codigo_Curso = Codigo_Curso.Value,
                    Nombre_Curso = Nombre_Curso.Value,
                    Codigo_Carrera = Codigo_Carrera.Value

                };


                string codigoresulta = api_Cursos.InsertarCursos(NuevaC);
                switch (codigoresulta)
                {
                    case "1":
                        string msg = "La Carrera se agrego con exito";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "');window.location ='Default.aspx';", true);
                        Response.Redirect("Default.aspx");
                        Codigo_Curso.Value = "";
                        Nombre_Curso.Value = "";
                        Codigo_Carrera.Value = "";
                        break;
                    case "2":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + "La Carrera que esta intentando ingresar ya fue registrada" + "');window.location ='Default.aspx';", true);
                        Response.Redirect("Default.aspx");
                        break;

                    default:
                        ScriptManager.RegisterStartupScript(this, GetType(),
                    "alert",
                    "alert('" + codigoresulta + "');window.location ='Default.aspx';", true);
                        Response.Redirect("Default.aspx");
                        break;
                }

            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "');window.location ='Default.aspx';", true);

            }


        }

       
        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx"); 
        }
    }
}