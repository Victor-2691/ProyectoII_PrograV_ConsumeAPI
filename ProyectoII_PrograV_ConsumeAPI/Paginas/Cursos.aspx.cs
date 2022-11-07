﻿using ConsumeApis.APIS;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                List<Cursos> curso = new List<Cursos>();

                GriedvCursos.DataSource = ApiCar.ConsultaCursos();
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
            Response.Redirect("AgregarCurso.aspx");
        }

        protected void GriedvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}