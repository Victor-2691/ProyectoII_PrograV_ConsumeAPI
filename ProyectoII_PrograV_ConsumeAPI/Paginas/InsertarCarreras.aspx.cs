using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsumeApis.Clases;
using QuickType;
using CarreraInsertar;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class InsertarCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_GuardarCarrera_Click(object sender, EventArgs e)
        {
            try
            {

                Api_Carreras Apicarrera = new Api_Carreras();

              carrerainsertar NuevoCarrera = new carrerainsertar()
                {
                 NombreCarrera = txtNombre_Carrera.Value,
                 Codigocarrera = txtCodigo_Carrera.Value  
                };
                string codigoresulta = Apicarrera.InsertarCarreras(NuevoCarrera);
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
                        "alert('" + "La carrera que esta intentando registrar ya existe" + "')", true);


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


            }


        }

        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carreras.aspx"); 
        }

      
    }
}