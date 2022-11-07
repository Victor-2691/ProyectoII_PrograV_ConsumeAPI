using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class InsertarCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_GuardarCarrera_Click(object sender, EventArgs e)
        {
       /*   try
            {
                Api_Carreras ApiCarrara = new Api_Carreras();

                Carreras NuevaC = new Carreras()
                {
                    Codigo_Carrera = Codigo_Carrera.Value,
                    Nombre_Carrera = Nombre_Carrera.Value

                };


                string codigoresulta = ApiCarrara.InsertarCarreras(NuevaC);
                switch (codigoresulta)
                {
                    case "1":
                        string msg = "La Carrera se agrego con exito";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "');window.location ='Default.aspx';", true);
                        Response.Redirect("Default.aspx");
                        Codigo_Carrera.Value = "";
                        Nombre_Carrera.Value = "";
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
            Response.Redirect("Carreras.aspx");*/
        }

        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carreras.aspx"); 
        }
    }
}