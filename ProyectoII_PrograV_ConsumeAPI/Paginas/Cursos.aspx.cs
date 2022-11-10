using ConsumeApis;
using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class Cursos : System.Web.UI.Page
    {
        private Api_Cursos ApiCar = new Api_Cursos();
        public List<Cursos> curso = new List<Cursos>();



        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!Page.IsPostBack)
                {

                    GriedvCursos.DataSource = ApiCar.ObtenerCursos();
                    GriedvCursos.DataBind();
                }


            }
            catch (Exception)
            {

              


            }
        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCursos.aspx");
        }



        protected void GriedvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string CodigoCurso = "";
            string Nombre = "";
            string CodigoCarrera = "";


            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GriedvCursos.Rows[index];
                    CodigoCurso = fila.Cells[1].Text;
                    Nombre = fila.Cells[2].Text;
                    CodigoCarrera = fila.Cells[3].Text;

                    Response.Redirect("ActualizaCursos.aspx?CodigoCur=" + CodigoCurso
                        + "&Nom=" + Nombre + "&CodiCarr=" + CodigoCarrera);


                }

            }
            catch (Exception ex)
            {


                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + msg + "')", true);
            }

            try
            {

                if (e.CommandName == "Eliminar")
                {
                    string respuesta = Codi.Value.ToString();

                    if (respuesta == "si")
                    {
                        int index = int.Parse(e.CommandArgument.ToString());
                        GridViewRow fila = GriedvCursos.Rows[index];
                        string Id = fila.Cells[1].Text;
                      string codigoretorno = ApiCar.EliminarCurso(Id);
                        switch (codigoretorno)
                        {
                            case "200":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "El curso se elimino con exito" + "')", true);
                                GriedvCursos.DataSource = ApiCar.ObtenerCursos();
                                GriedvCursos.DataBind();
                                break;

                            case "404":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El curso no se encuentra en la base de datos" + "')", true);
                               
                                break;


                            case "500":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El curso no se puede eliminar" + "')", true);
                        
                                break;



                            default:
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + codigoretorno + "')", true);

                                break;

                        }


                    }

                }



            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + ex + "')", true);

            }   

 
             }
         }
    }
