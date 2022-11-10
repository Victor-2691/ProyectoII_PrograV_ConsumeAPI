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

        public List<estudiante2> estudiante2s = new List<estudiante2>();
        public string Codigo_Curso { get; internal set; }
        public string Nombre_Curso { get; internal set; }
        public string Codigo_Carrera { get; internal set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

             
                GriedvCursos.DataSource = ApiCar.ObtenerCursos();
                GriedvCursos.DataBind();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + msg + "');window.location ='Cursos.aspx';", true);


            }
        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCursos.aspx");
        }

     

        protected void GriedvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {






        }
    }
}
