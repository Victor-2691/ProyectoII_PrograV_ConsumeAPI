using ConsumeApis.APIS;
using ConsumeApis.Clases;
using grupos_insertar;
using periodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class ActualizaGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    List<profesorConsulta> ListaProf = new List<profesorConsulta>();
                    Api_Profesores ApiProfesores = new Api_Profesores();
                    ListaProf = ApiProfesores.ListarTodosProfesor();
                 

                    txt_numgrupo.Value = Request.QueryString["numgru"];
                    txt_codigocurso.Value = Request.QueryString["codigocurs"];
                    txt_nombrecurso.Value = Request.QueryString["nombrecurs"];
                    txt_year.Value = Request.QueryString["years"];
                    txt_numeroperiodo.Value = Request.QueryString["numperiodo"];
                    txt_primerApellido.Value = Request.QueryString["primerApell"];
                    string tipoid = Request.QueryString["tipoidi"];
                    string nombreProfe = Request.QueryString["nomprofe"];
                    string id = Request.QueryString["id"];
                    string horario = Request.QueryString["horario"];
            

                  
                    foreach (var item in ListaProf)
                    {
                        if (item.Identificacion == id && item.TipoId == tipoid)
                        {
                            txt_segudoApellido.Value = item.SegundoApellido;
                            break;
                        }
                    }


                    DropDownListNombreProfesor.Items.Add(nombreProfe);
                    DropDownListNombreProfesor.Items.Add("Cargar profesores");
                    txt_tipoid.Value = tipoid;
                    txt_identifiacion.Value = id;
                  

                    switch (horario)
                    {
                        case "mana":
                            ListItem a;
                            a = new ListItem("Mañana", "Mañana");
                            DropDownListHorario.Items.Add(a);
                            a = new ListItem("Tarde", "Tarde");
                            DropDownListHorario.Items.Add(a);
                            a = new ListItem("Noche", "Noche");
                            DropDownListHorario.Items.Add(a);
                            break;

                        case "Tarde":
                            ListItem b;
                            b = new ListItem("Tarde", "Tarde");
                            DropDownListHorario.Items.Add(b);
                            b = new ListItem("Mañana", "Mañana");
                            DropDownListHorario.Items.Add(b);
                            b = new ListItem("Noche", "Noche");
                            DropDownListHorario.Items.Add(b);

                            break;


                        case "Noche":
                            ListItem c;
                            c = new ListItem("Noche", "Noche");
                            DropDownListHorario.Items.Add(c);
                            c = new ListItem("Tarde", "Tarde");
                            DropDownListHorario.Items.Add(c);
                            c = new ListItem("Mañana", "Mañana");
                            DropDownListHorario.Items.Add(c);
                            break;
                        default:
                            break;
                    }




                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(),
                 "alert",
                   "alert('" + ex.Message + "')", true);
            }
           
        }

        protected void btn_actualiza_Click(object sender, EventArgs e)
        {
            try
            {
            
                Grupo G = new Grupo()
                {
                   Numerogrupo = int.Parse(txt_numgrupo.Value),
                   Codigocurso = txt_codigocurso.Value,
                   Identificacion = txt_identifiacion.Value,
                   Horario = DropDownListHorario.SelectedValue,
                   Anno = int.Parse(txt_year.Value),
                   NumeroPeriodo = int.Parse(txt_numeroperiodo.Value),
                   TipoId = txt_tipoid.Value,
                };
                Api_Grupos ApiGrup = new Api_Grupos();

                String CodioRespuesta = ApiGrup.ActulizaGrupo(G);
                switch (CodioRespuesta)
                {
                    case "200":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert", "alert('" + "El grupo se actualizo con exito" + "')", true);

                        break;

                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                 "alert", "alert('" + "El grupo no se encuentra" + "')", true);
                        break;

                    case "500":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                    "alert", "alert('" + "Error de servidor" + "')", true);
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

        protected void DropDownListNombreProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<profesorConsulta> ListaProf = new List<profesorConsulta>();
                Api_Profesores ApiProfesores = new Api_Profesores();
                ListaProf = ApiProfesores.ListarTodosProfesor();
                if (DropDownListNombreProfesor.SelectedValue == "Cargar profesores")
                {
                    DropDownListNombreProfesor.Items.Remove("Cargar profesores");
                    DropDownListNombreProfesor.Items.Clear();
              
                    DropDownListNombreProfesor.DataSource = ListaProf;
                    DropDownListNombreProfesor.DataTextField = "Nombre";
                    DropDownListNombreProfesor.DataValueField = "Identificacion";
                    DropDownListNombreProfesor.DataBind();


                }
                string id = DropDownListNombreProfesor.SelectedValue;
                foreach (var item in ListaProf)
                {
                    if (item.Identificacion == id)
                    {
                        txt_identifiacion.Value = item.Identificacion;
                        txt_primerApellido.Value = item.PrimerApellido;
                        txt_segudoApellido.Value = item.SegundoApellido;
                        txt_tipoid.Value = item.TipoId;
                        break;

                    }

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(),
                 "alert",
                   "alert('" + ex.Message + "')", true);
            }




        }
    }
}