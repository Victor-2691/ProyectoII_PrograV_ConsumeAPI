using claseconsume;
using ConsumeApis.APIS;
using grupos_consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class GruposPrincipal : System.Web.UI.Page
    {
        public Api_Grupos Apigrupos = new Api_Grupos();
        public List< Gruposconsulta> ListaGrupos = new List<Gruposconsulta>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaGrupos = Apigrupos.ListarGrupos();
            if (!Page.IsPostBack)
            {
                try
                {
                    if (ListaGrupos == null)
                    {

                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);

                    }
                    else
                    {

                        GridPeriodo.DataSource = ListaGrupos;
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

        protected void GridPeriodo_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string numerogrupo = "";
            string codigocurso = "";
            string identificacion = "";
            string tipoId = "";
            string year = "";
            string numeroPeriodo = "";
            string horario = "";
            string nombrecurso = "";
            string nombreprofesor = "";
            string primerApellido = "";
            


            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GridPeriodo.Rows[index];
                    numerogrupo = fila.Cells[1].Text;
                    codigocurso = fila.Cells[2].Text;
                    nombrecurso = fila.Cells[3].Text;
                    year = fila.Cells[5].Text;
                    numeroPeriodo = fila.Cells[6].Text;
                    nombreprofesor = fila.Cells[8].Text;
                    tipoId = fila.Cells[10].Text;
                    identificacion = fila.Cells[11].Text;
                    horario = fila.Cells[7].Text;
                    primerApellido = fila.Cells[9].Text;
                    if (horario== "Ma&#241;ana")
                    {
                        horario = "mana";

                    }
               

                    Response.Redirect("ActualizaGrupos.aspx?numgru=" + numerogrupo
                        + "&codigocurs=" + codigocurso + "&id=" + identificacion
                        + "&horario=" + horario + "&nombrecurs=" + nombrecurso
                      + "&tipoidi=" + tipoId + "&years=" + year + "&numperiodo=" + numeroPeriodo
                      + "&nomprofe=" + nombreprofesor + "&primerApell=" + primerApellido
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
                        string numgrupo = fila.Cells[1].Text;
                        string codigoC = fila.Cells[2].Text;
                        string id = numgrupo + "_" + codigoC;
                        string codigoretorno = Apigrupos.EliminaGrupo(id);

                        switch (codigoretorno)
                        {
                            case "200":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "El grupo se elimino con exito" + "')", true);
                                ListaGrupos = Apigrupos.ListarGrupos();
                                GridPeriodo.DataSource = ListaGrupos;
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarGrupo.aspx");
        }
    }
}