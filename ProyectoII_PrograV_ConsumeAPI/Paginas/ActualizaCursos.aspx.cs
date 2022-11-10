using CarreraInsertar;
using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickType2;
namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class ActualizaCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               txtCodigo_Curso.Value = Request.QueryString["CodigoCur"];
                txtNombre_Curso.Value = Request.QueryString["Nom"];
                txtCodigo_Carrera.Value = Request.QueryString["CodiCarr"]
;


            }

        }

        protected void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx");
        }

        protected void btn_GuardarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                cursoActualiza C = new cursoActualiza()
                {
                    CodigoCurso = txtCodigo_Curso.Value,
                    NombreCurso = txtNombre_Curso.Value,
                    CodigoCarrera = txtCodigo_Carrera.Value
                };
                Api_Cursos apiCursos = new Api_Cursos();

                String CodioRespuesta = apiCursos.ActulizarCurso(C);
                switch (CodioRespuesta)
                {
                    case "200":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert", "alert('" + "El curso se actualizo con exito" + "')", true);

                        break;

                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                 "alert", "alert('" + "El curso no se encuentra en la base de datos" + "')", true);
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
  
        }
    }
