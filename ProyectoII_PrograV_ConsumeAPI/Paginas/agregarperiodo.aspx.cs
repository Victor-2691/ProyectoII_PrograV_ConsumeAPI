using ConsumeApis.APIS;
using periodos;
using pruebaconsumeAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class agregarperiodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListItem i;
                i = new ListItem("I", "1");
                DropDownListPeriodo.Items.Add(i);
                i = new ListItem("II", "2");
                DropDownListPeriodo.Items.Add(i);
                i = new ListItem("III", "3");
                DropDownListPeriodo.Items.Add(i);


                ListItem a;
                a = new ListItem("Activo", "A");
                DropDownListEstadoPeriodo.Items.Add(a);
                a = new ListItem("Futuro", "F");
                DropDownListEstadoPeriodo.Items.Add(a);
                a = new ListItem("Pasado", "P");
                DropDownListEstadoPeriodo.Items.Add(a);

            }

      
        


        }

        protected void btn_GuardarEstudia_Click(object sender, EventArgs e)
        {
            try
            {

                Api_Periodos ApiPeriodos = new Api_Periodos();
                int periodo = int.Parse(DropDownListPeriodo.SelectedValue);
                string estado = "";
                if (DropDownListEstadoPeriodo.SelectedValue.Contains("F"))
                {
                    estado = "F";
                }
                if (DropDownListEstadoPeriodo.SelectedValue.Contains("P"))
                {
                    estado = "P";
                }
                if (DropDownListEstadoPeriodo.SelectedValue.Contains("A"))
                {
                    estado = "A";
                }

                Periodo P = new Periodo()
                {
                    
                    Anno = int.Parse(txt_year.Value),
                    NumeroPeriodo = periodo,
                    Estado = estado,
                    FechaInicio = txt_fecha_Inicio.Value,
                    Fechafinal = txt_fecha_cierre.Value,
                };
                string codigoresulta = ApiPeriodos.InsertarPeriodo(P);  
                switch (codigoresulta)
                {
                    case "1":

                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + "Se agrego con exito" + "')", true);

                        break;
                    case "2":

                        ScriptManager.RegisterStartupScript(this, GetType(),
                        "alert",
                        "alert('" + "El periodo que esta intentando registrar ya existe" + "')", true);


                        break;

                    default:

                        ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert",
                          "alert('" + codigoresulta + "')", true);

                        break;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(),
               "alert",
               "alert('" + ex.Message + "')", true);
            

            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("periodos.aspx");

        }
    }
}