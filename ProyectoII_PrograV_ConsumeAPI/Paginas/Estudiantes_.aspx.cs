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

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEstudiante.aspx");

        }
        protected void GriedvEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string TipoID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["TipoId"]);
            string ID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["Identificacion"]);


        }

    
        protected void GriedvEstudiantes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string TipoID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["TipoId"]);
            string ID = Convert.ToString(GriedvEstudiantes.DataKeys[e.RowIndex].Values["Identificacion"]);
            string Nombre="";
            string primerApellido="";
            string segundApellido = "";
            string fechaNacimiento = "";

            foreach (var item in estudiante2s )
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
                +"&Id="+ID +"&Nomb=" + Nombre+"&PrimerApel=" + primerApellido
                +"&SegundApp=" + segundApellido + "&FechaNacimie=" + fechaNacimiento );
        }

        protected void GriedvEstudiantes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
       
        }

        protected void GriedvEstudiantes_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
  
}