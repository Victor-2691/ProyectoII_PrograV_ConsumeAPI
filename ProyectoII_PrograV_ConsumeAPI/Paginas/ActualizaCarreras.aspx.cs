using CarreraInsertar;
using ConsumeApis.APIS;
using ConsumeApis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class ActualizaCarreras : System.Web.UI.Page
    {
        public Api_Carreras Apicarrera = new Api_Carreras();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtCodigo_Carrera.Value = Request.QueryString["Cod"];
                 txtNombre_Carrera.Value = Request.QueryString["Nom"];
     


            }

        }

        protected void btn_GuardarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                carrerainsertar C = new carrerainsertar()
                {
                   Codigocarrera = txtCodigo_Carrera.Value,
                   NombreCarrera = txtNombre_Carrera.Value
                };

                String CodioRespuesta = Apicarrera.ActulizarCarrera(C);
                switch (CodioRespuesta)
                {
                    case "200":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert", "alert('" + "La carrera se actualizo con exito" + "')", true);

                        break;

                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                 "alert", "alert('" + "La carrera no se encuentra en la base de datos" + "')", true);
                        Response.Redirect("Estudiantes_.aspx");
                        break;

                    case "500":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                 "alert", "alert('" + "Error de servidor" + "')", true);
                        Response.Redirect("Estudiantes_.aspx");
                        break;


                    default:
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                 "alert", "alert('" + CodioRespuesta + "')", true);

                        break;

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "alert", "alert('" + ex.Message + "')", true);

            }

        }

        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carreras.aspx");
        }
    }
}