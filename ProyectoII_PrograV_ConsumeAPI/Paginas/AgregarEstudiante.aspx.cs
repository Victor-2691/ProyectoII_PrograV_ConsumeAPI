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

                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + "Se agrego con exito" + "')", true);

                        break;
                    case "2":

                        ScriptManager.RegisterStartupScript(this, GetType(),
                        "alert",
                        "alert('" + "El estudiante que esta intentando registrar ya existe" + "')", true);


                        break;

                    default:

                        ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert",
                          "alert('" + codigoresulta + "')", true);

                        break;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + ex.Message + "')", true);
                txt_nombre.Value = "";
                txt_PrimerApellido.Value = "";

            }



        }

        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estudiante.aspx"); 
        }
    }
}