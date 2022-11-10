using ConsumeApis;
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
    public partial class ActualizaProfesor : System.Web.UI.Page
    {
        public Api_Profesores ApiProfesores = new Api_Profesores();
    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txt_tipoId.Value = Request.QueryString["Tipoid"];
                txt_identificaci.Value = Request.QueryString["Id"];
                txt_nombre.Value = Request.QueryString["Nomb"];
                txt_PrimerApellido.Value = Request.QueryString["PrimerApel"];
                txt_segundoApellido.Value = Request.QueryString["SegundApp"];


            }

        }

        protected void Btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                profesorConsulta E2 = new profesorConsulta()
                {
                    TipoId = txt_tipoId.Value,
                    Identificacion = txt_identificaci.Value,
                    Nombre = txt_nombre.Value,
                    PrimerApellido = txt_PrimerApellido.Value,
                    SegundoApellido = txt_segundoApellido.Value,
                    FechaNacimiento = txt_fecha.Value,
                };

                String CodioRespuesta = ApiProfesores.ActulizarEstudiante(E2);
                switch (CodioRespuesta)
                {
                    case "200":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert", "alert('" + "El estudiante se actualizo con exito" + "')", true);

                        break;

                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                 "alert", "alert('" + "El estudiante no se encuentra en la base de datos" + "')", true);
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

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profesores_.aspx");

        }
    }
}