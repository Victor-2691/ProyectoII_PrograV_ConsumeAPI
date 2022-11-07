using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 using ConsumeApis.APIS;
using pruebaconsumeAPI;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{

    public partial class AgregarEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_GuardarEstudia_Click(object sender, EventArgs e)
        {
            try
            {

                Api_Estudiantecs ApiconsuemEstudiante = new Api_Estudiantecs();

                estudiante NuevoEst = new estudiante()
                {
                    Identificacion = txt_identificaci.Value,
                    TipoId = txt_tipoId.Value,
                    Nombre = txt_nombre.Value,
                    PrimerApellido = txt_PrimerApellido.Value,
                    SegundoApellido = txt_segundoApellido.Value,
                    FechaNacimiento = txt_fecha.Value,
                    CorreoEle = txt_Correos.Value,
                    NumerosTelefono = txt_Numtelefonos.Value
                };
                string codigoresulta = ApiconsuemEstudiante.insetarEstudiante(NuevoEst);
                switch (codigoresulta)
                {
                    case "1":
                        string msg = "El estudiante se agrego con exito";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "');window.location ='Default.aspx';", true);
                        Response.Redirect("Default.aspx");
                        txt_nombre.Value = "";
                        txt_PrimerApellido.Value = "";
                        break;
                    case "2":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + "El estudiante que esta intenta ingresar ya fue registrado" + "');window.location ='Default.aspx';", true);
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

        }
    }
}