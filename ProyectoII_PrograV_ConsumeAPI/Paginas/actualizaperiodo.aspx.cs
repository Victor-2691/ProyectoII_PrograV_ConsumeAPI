using ConsumeApis.APIS;
using periodos;
using QuickType2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class actualizaperiodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string fechainicio = Request.QueryString["fechainicio"];
                string fechafinal = Request.QueryString["fechafinal"];
                string[] arrayf1 = fechainicio.Split('/');
                string[] arrayf2 = fechafinal.Split('/');
                fechainicio = arrayf1[2].Substring(0, 4) + "-" + arrayf1[1] + "-" + arrayf1[0];
                fechafinal = arrayf2[2].Substring(0, 4) + "-" + arrayf2[1] + "-" + arrayf2[0];
                txt_year.Value = Request.QueryString["anno"];
                txt_numeroperiodo.Value = Request.QueryString["numperiodo"];
                txt_fecha_Inicio.Value = fechainicio;
                txt_fecha_cierre.Value = fechafinal;
         
                string estado = Request.QueryString["estado"];
             
                switch (estado)
                {
                    case "A":
                        ListItem a;
                        a = new ListItem("Activo", "A");
                        DropDownListEstadoPeriodo.Items.Add(a);
                        a = new ListItem("Futuro", "F");
                        DropDownListEstadoPeriodo.Items.Add(a);
                        a = new ListItem("Pasado", "P");
                        DropDownListEstadoPeriodo.Items.Add(a);
                        break;

                    case "P":
                        ListItem b;
                        b = new ListItem("Pasado", "P");
                        DropDownListEstadoPeriodo.Items.Add(b);
                        b = new ListItem("Activo", "A");
                        DropDownListEstadoPeriodo.Items.Add(b);
                        b = new ListItem("Futuro", "F");
                        DropDownListEstadoPeriodo.Items.Add(b);
             
                        break;


                    case "F":
                        ListItem c;
                        c = new ListItem("Futuro", "F");
                        DropDownListEstadoPeriodo.Items.Add(c);
                        c = new ListItem("Activo", "A");
                        DropDownListEstadoPeriodo.Items.Add(c);
                        c = new ListItem("Pasado", "P");
                        DropDownListEstadoPeriodo.Items.Add(c);
                        break;



                    default:
                        break;
                }



            

            }
         



        }

        protected void btn_GuardarEstudia_Click(object sender, EventArgs e)
        {
            try
            {
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
                 NumeroPeriodo = int.Parse(txt_numeroperiodo.Value),
                 FechaInicio = txt_fecha_Inicio.Value,
                 Fechafinal = txt_fecha_cierre.Value,
                 Estado = estado,
                };
                Api_Periodos apiperiod = new Api_Periodos();

                String CodioRespuesta = apiperiod.ActulizarPeriodo(P);
                switch (CodioRespuesta)
                {
                    case "200":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert", "alert('" + "El periodo se actualizo con exito" + "')", true);

                        break;

                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "alert", "alert('" + "El periodo no se encuentra" + "')", true);
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