using ConsumeApis;
using ConsumeApis.APIS;
using ConsumeApis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickType;
using pruebaconsumeAPI;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class Carreras : System.Web.UI.Page
    {
        private Api_Carreras ApiCar = new Api_Carreras();

       public List<carrera> Listacarrera = new List<carrera>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    Listacarrera = ApiCar.ConsultaCarreras();

                    if (Listacarrera == null)
                    {

                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);

                    }
                    else
                    {
                       GriedvCarreras.DataSource = Listacarrera;
                        GriedvCarreras.DataBind();
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
           

        protected void GriedvCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAgrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertarCarreras.aspx");
        }

        protected void GriedvCarreras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Codigo = "";
            string Nombre = "";
      

            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GriedvCarreras.Rows[index];
                    Codigo  = fila.Cells[1].Text;
                    Nombre = fila.Cells[2].Text;

                    Response.Redirect("ActualizaCarreras.aspx?Cod=" + Codigo
                        + "&Nom=" + Nombre);


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
                        GridViewRow fila = GriedvCarreras.Rows[index];
                        string Id = fila.Cells[1].Text;
                        string codigoretorno = ApiCar.EliminaCarrera(Id);

                        switch (codigoretorno)
                        {
                            case "200":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "La carrera se elimino con exito" + "')", true);

                                GriedvCarreras.DataSource = ApiCar.ConsultaCarreras();
                                GriedvCarreras.DataBind();
                                break;

                            case "404":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + " no se encuentra en la base de datos" + "')", true);

                                break;

                            case "500":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "No es valido eliminar " + "')", true);

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
    }
}