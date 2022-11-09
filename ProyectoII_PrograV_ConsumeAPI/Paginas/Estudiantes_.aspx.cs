using ConsumeApis;
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
    public partial class Estudiantes_ : System.Web.UI.Page
    {
        private Api_Estudiantecs ApiconsuemEstudiante = new Api_Estudiantecs();
        public List<estudiante2> estudiante2s = new List<estudiante2>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    estudiante2s = ApiconsuemEstudiante.ConsultaEstudiantes();

                    if (estudiante2s == null)
                    {

                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);

                    }
                    else
                    {
                        GriedvEstudiantes.DataSource = ApiconsuemEstudiante.ConsultaEstudiantes();
                        GriedvEstudiantes.DataBind();
                    }



                }
                catch (Exception ex)
                {

                    string msg = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + msg + "')", true);



                }

            }

        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEstudiante.aspx");

        }
      
        //protected void GriedvEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
       // {
         //   string TipoID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["TipoId"]);
           // string ID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["Identificacion"]);
        //}


   
    

        protected void GriedvEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          

                string TipoID = "";
                string ID = "";
                string Nombre = "";
                string primerApellido = "";
                string segundApellido = "";
                string fechaNacimiento = "";

            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GriedvEstudiantes.Rows[index];
                    TipoID = fila.Cells[1].Text;
                    ID = fila.Cells[2].Text;
                    List<estudiante2> DatosEstudiante = new List<estudiante2>();
                    DatosEstudiante = ApiconsuemEstudiante.ConsultaEstudiantes();

                    foreach (var item in DatosEstudiante)
                    {
                        if (item.TipoId == TipoID & item.Identificacion == ID)
                        {
                            Nombre = item.Nombre;
                            primerApellido = item.PrimerApellido;
                            segundApellido = item.SegundoApellido;
                            fechaNacimiento = item.FechaNacimiento;
                        }
                    }

                    Response.Redirect("ActualizaEstudiante.aspx?Tipoid=" + TipoID
                        + "&Id=" + ID + "&Nomb=" + Nombre + "&PrimerApel=" + primerApellido
                        + "&SegundApp=" + segundApellido + "&FechaNacimie=" + fechaNacimiento);


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
                        GridViewRow fila = GriedvEstudiantes.Rows[index];
                        string tipoId = fila.Cells[1].Text;
                        string Id = fila.Cells[2].Text;
                        string Llaves = Id + "-" + tipoId;
                        string codigoretorno = ApiconsuemEstudiante.EliminaEstudiante(Llaves);

                        switch (codigoretorno)
                        {
                            case "204":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "El estudiante se elimino con exito" + "')", true);

                                GriedvEstudiantes.DataSource = ApiconsuemEstudiante.ConsultaEstudiantes();
                                GriedvEstudiantes.DataBind();
                                break;

                            case "404":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El estudiante no se encuentra en la base de datos" + "')", true);
                                Response.Redirect("Estudiantes_.aspx");
                                break;
                            default:
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + codigoretorno + "')", true);

                                break;

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + msg + "')", true);
            }

              
            
   
            
        


        }

        protected void GriedvEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GriedvEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }

}

