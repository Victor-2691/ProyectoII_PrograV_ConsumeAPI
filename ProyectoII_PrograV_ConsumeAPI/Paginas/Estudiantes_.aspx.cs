using ConsumeApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsumeApis.APIS;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class Estudiantes_ : System.Web.UI.Page
    {
       private Api_Estudiantecs ApiconsuemEstudiante = new Api_Estudiantecs();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<estudiante2> estudiante2s = new List<estudiante2>();
                estudiante2s = ApiconsuemEstudiante.ConsultaEstudiantes();

                if (estudiante2s == null)
                {
                    string msg = "No se encontraron los datos";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + msg + "');window.location ='Default.aspx';", true);

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
               "alert('" + msg + "');window.location ='Default.aspx';", true);
            

            }

        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEstudiante.aspx");

        }
    }
}