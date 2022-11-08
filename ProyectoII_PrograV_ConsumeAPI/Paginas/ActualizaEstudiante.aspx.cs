using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class ActualizaEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txt_tipoId.Value = Request.QueryString["Tipoid"];
                txt_identificaci.Value = Request.QueryString["Id"];
                txt_nombre.Value = Request.QueryString["Nom"];
                txt_PrimerApellido.Value = Request.QueryString["PrimerApel"];
                txt_segundoApellido.Value = Request.QueryString["SegundApp"];
                
            }
        }

        protected void btn_ActualizaEstudiante_Click(object sender, EventArgs e)
        {

        }
    }
}