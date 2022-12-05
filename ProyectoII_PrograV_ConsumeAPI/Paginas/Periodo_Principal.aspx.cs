using claseconsume;
using ConsumeApis.APIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class Periodo_Principal : System.Web.UI.Page
    {
        public Api_Periodos apiperiodo = new Api_Periodos();
        public Periodoconsulta ConsultaPeriodo = new Periodoconsulta();
        public List<Periodoconsulta> ListaPeriodos = new List<Periodoconsulta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaPeriodos = apiperiodo.ListarPeriodosOrdenados();
            if (!Page.IsPostBack)
            {
                try
                {
                    if (ListaPeriodos == null)
                    {

                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);

                    }
                    else
                    {

                        GridPeriodo.DataSource = ListaPeriodos;
                        GridPeriodo.DataBind();
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

        protected void Btnagrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarperiodo.aspx");
        }

        protected void GridPeridos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string anno = "";
            string fechainicio = "";
            string fechafinal = "";
            string numperiodo = "";
            string estado = "";


            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GridPeriodo.Rows[index];
                    anno = fila.Cells[1].Text;
                    fechainicio = fila.Cells[2].Text;
                    fechafinal = fila.Cells[3].Text;
                    numperiodo = fila.Cells[4].Text;
                    estado = fila.Cells[5].Text;

                    Response.Redirect("Actualizaperiodo.aspx?anno=" + anno
                        + "&fechainicio=" + fechainicio + "&fechafinal=" + fechafinal
                        + "&numperiodo=" + numperiodo + "&estado=" + estado
                        );


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
                        GridViewRow fila = GridPeriodo.Rows[index];
                        string year = fila.Cells[1].Text;
                        string periodo = fila.Cells[4].Text;
                        string id = year + "-" + periodo;
                        string codigoretorno = apiperiodo.EliminaPeriodo(id);

                        switch (codigoretorno)
                        {
                            case "200":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "La carrera se elimino con exito" + "')", true);
                                ListaPeriodos = apiperiodo.ListarPeriodosOrdenados();
                                GridPeriodo.DataSource = ListaPeriodos;
                                GridPeriodo.DataBind();
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