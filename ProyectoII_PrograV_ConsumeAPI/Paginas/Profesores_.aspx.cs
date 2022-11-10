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
    public partial class Profesores_ : System.Web.UI.Page
    {
        public Api_Profesores ApiProfesores = new Api_Profesores();
        public List<profesorConsulta> ListaProf = new List<profesorConsulta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (ListaProf == null)
                    {

                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);

                    }
                    else
                    {
                        ListaProf = ApiProfesores.ListarTodosProfesor();
                        GridViProfesores.DataSource = ListaProf;
                        GridViProfesores.DataBind();
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


        protected void GridViProfesores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string TipoID = "";
            string ID = "";
            string Nombre = "";
            string primerApellido = "";
            string segundApellido = "";
            string fechaNacimiento = "";

            try
            {
                if (e.CommandName == "Actualiza")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow fila = GridViProfesores.Rows[index];
                    TipoID = fila.Cells[1].Text;
                    ID = fila.Cells[2].Text;
                    List<profesorConsulta> DatosEstudiante = new List<profesorConsulta>();
                    DatosEstudiante = ApiProfesores.ListarTodosProfesor();

                    foreach (var item in DatosEstudiante)
                    {
                        if (item.TipoId == TipoID & item.Identificacion == ID)
                        {
                            Nombre = item.Nombre;
                            primerApellido = item.PrimerApellido;
                            segundApellido = item.SegundoApellido;
                            fechaNacimiento = item.FechaNacimiento;
                        }
                    }

                    Response.Redirect("ActualizaProfesor.aspx?Tipoid=" + TipoID
                        + "&Id=" + ID + "&Nomb=" + Nombre + "&PrimerApel=" + primerApellido
                        + "&SegundApp=" + segundApellido + "&FechaNacimie=" + fechaNacimiento);


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
                        GridViewRow fila = GridViProfesores.Rows[index];
                        string tipoId = fila.Cells[1].Text;
                        string Id = fila.Cells[2].Text;
                        string llaves = Id + "-" + tipoId;
                        string codigoretorno = ApiProfesores.EliminaEstudiante(llaves);

                        switch (codigoretorno)
                        {
                            case "204":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "alert", "alert('" + "El profesor se elimino con exito" + "')", true);

                                GridViProfesores.DataSource = ApiProfesores.ListarTodosProfesor();
                                GridViProfesores.DataBind();
                                break;

                            case "404":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El profesor no se encuentra en la base de datos" + "')", true);
                                
                                break;

                            case "500":
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "No es valido eliminar" + "')", true);

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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<profesorConsulta> ListaProf2 = new List<profesorConsulta>();

                if (txt_identificaci.Value.Trim() == "" & txt_tipoId.Value.Trim() == "" & txt_nombre.Value.Trim() == "")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "alert",
                   "alert('" + "Debe ingresar alguno de los valores para poder realizar la busqueda" + "')", true);

                }

                //Buscar por ID todos los campos llenos
                if (txt_identificaci.Value.Length > 0 & txt_tipoId.Value.Length > 0 & txt_nombre.Value.Length > 0)
                {
                    //Buscar por ID
                    ListaProf = ApiProfesores.BuscarProfesorID(txt_identificaci.Value, txt_tipoId.Value);
                    if (ListaProf2 == null)
                    {
                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);
                    }
                    else
                    {
                        GridViProfesores.DataSource = null;
                        GridViProfesores.DataSource = ListaProf2;
                        GridViProfesores.DataBind();

                    }


                }


                // Buscar por ID
                if (txt_identificaci.Value.Length > 0 & txt_tipoId.Value.Length > 0)
                {
                    //Buscar por ID
                    ListaProf2 = ApiProfesores.BuscarProfesorID(txt_identificaci.Value, txt_tipoId.Value);
                    if (ListaProf2 == null)
                    {
                        string msg = "No se encontraron datos";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                       "alert",
                       "alert('" + msg + "')", true);
                    }
                    else
                    {
                        GridViProfesores.DataSource = null;
                        GridViProfesores.DataSource = ListaProf2;
                        GridViProfesores.DataBind();

                    }
                }
                else
                {

                    //Buscar por nombre
                    if (txt_nombre.Value.Length > 0)
                    {
                        //Buscar por nombre
                        List<profesorConsulta> ListaProf3 = new List<profesorConsulta>();
                        ListaProf3 = ApiProfesores.BuscarProfesorNombre(txt_nombre.Value);
                        if (ListaProf3 == null)
                        {
                            string msg = "No se encontraron datos";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                           "alert",
                           "alert('" + msg + "')", true);
                        }
                        else
                        {
                            GridViProfesores.DataSource = null;
                            GridViProfesores.DataSource = ListaProf3;
                            GridViProfesores.DataBind();
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

        protected void BtnBorrarFiltro_Click(object sender, EventArgs e)
        {
            ListaProf = ApiProfesores.ListarTodosProfesor();
            GridViProfesores.DataSource = ListaProf;
            GridViProfesores.DataBind();
            txt_identificaci.Value = "";
            txt_tipoId.Value = "";
            txt_nombre.Value = "";
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProfesor.aspx");
        }
    }
}
