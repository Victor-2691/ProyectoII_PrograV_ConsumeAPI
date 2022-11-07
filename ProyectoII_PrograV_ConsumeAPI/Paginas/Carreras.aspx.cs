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
    public partial class Carreras : System.Web.UI.Page
    {
        private Api_Carreras ApiCar = new Api_Carreras();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                List<Carreras> carrera = new List<Carreras>();

                GriedvCarreras.DataSource = ApiCar.ConsultaCarreras();
                GriedvCarreras.DataBind();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + msg + "');window.location ='Carreras.aspx';", true);


            }

        }

        protected void GriedvCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertarCarreras.aspx");
        }
    }
}