using claseconsume;
using ConsumeApis.APIS;
using ConsumeApis.Clases;
using CursosC;
using grupos_insertar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoII_PrograV_ConsumeAPI.Paginas
{
    public partial class AgregarGrupo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (!Page.IsPostBack)
                {
                    Api_Cursos ApiCar = new Api_Cursos();
                    List<Curso> Listacurso = new List<Curso>();
                    Listacurso = ApiCar.ObtenerCursos();
                    DropDownListCursos.DataSource = Listacurso;
                    DropDownListCursos.DataTextField = "Nombre_Curso";
                    DropDownListCursos.DataValueField = "Codigo_Curso";
                    DropDownListCursos.DataBind();


                    Api_Periodos apiperiodo = new Api_Periodos();
                    List<Periodoconsulta> ListaPeriodos = new List<Periodoconsulta>();
                    ListaPeriodos = apiperiodo.ListarPeriodosOrdenados();
                    List<int> Listanueva = new List<int>();
                    foreach (var item in ListaPeriodos)
                    {
                        Listanueva.Add(item.Anno);

                    }
                    List<int> disctinct = Listanueva.Distinct().ToList();

                    DropDownListYear.AppendDataBoundItems = true;
                    DropDownListYear.Items.Add("seleccione un año");

                    foreach (var item in disctinct)
                    {
                        DropDownListYear.Items.Add(item.ToString());
                    }

                    //DropDownListYear.DataSource = ListaPeriodos;
                    //   DropDownListYear.DataTextField = "Anno";
                    //   DropDownListYear.DataValueField = "Anno";
                    //  DropDownListYear.DataBind();
                    DropDownListPeriodo.Items.Add("Seleccione un periodo");

                    ListItem i;
                    i = new ListItem("Mañana", "Mañana");
                    DropDownListHorario.Items.Add(i);
                    i = new ListItem("Tarde", "Tarde");
                    DropDownListHorario.Items.Add(i);
                    i = new ListItem("Noche", "Noche");
                    DropDownListHorario.Items.Add(i);

                    Api_Profesores ApiProfesores = new Api_Profesores();
                    List<profesorConsulta> ListaProf = new List<profesorConsulta>();
                    DropDownListNombreProfesor.AppendDataBoundItems = true;
                    DropDownListNombreProfesor.Items.Add("seleccione un profesor");
                    ListaProf = ApiProfesores.ListarTodosProfesor();
                    DropDownListNombreProfesor.DataSource = ListaProf;
                    DropDownListNombreProfesor.DataTextField = "Nombre";
                    DropDownListNombreProfesor.DataValueField = "Identificacion";
                    DropDownListNombreProfesor.DataBind();
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(),
         "alert",
         "alert('" + ex.Message + "')", true);
            }


          
        }

        protected void btn_GuardarEstudia_Click(object sender, EventArgs e)
        {
            try
            {
                Api_Grupos apigrupos = new Api_Grupos();

                Grupo G = new Grupo()
                {
                    Numerogrupo = int.Parse(txt_numgrupo.Value),
                    Codigocurso = DropDownListCursos.SelectedValue,
                    Identificacion = txt_identifiacion.Value,
                    TipoId = txt_tipoid.Value,
                    Horario= DropDownListHorario.SelectedValue,
                    Anno = int.Parse(DropDownListYear.SelectedValue),
                    NumeroPeriodo = int.Parse(DropDownListPeriodo.SelectedValue),
                };


                string codigoresulta = apigrupos.insetarGrupos(G);
                switch (codigoresulta)
                {
                    case "201":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                        "alert", "alert('" + "El curso se creo con exito" + "')", true);

                        break;
                    case "409":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                         "alert", "alert('" + "El curso ya se encuentra registrado en la BD" + "')", true);
                        break;


                    case "404":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                   "alert", "alert('" + "La carrera que ingreso no existe, por favor modifiquela" + "')", true);
                        break;

                    case "500":
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                   "alert", "alert('" + "Error interno servidor" + "')", true);
                        break;


                    default:
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                        "alert", "alert('" + codigoresulta + "')", true);
                        break;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                                   "alert", "alert('" + ex.Message + "')", true);

            }




        }

        protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DropDownListYear.Items.Remove("seleccione un año");
                Api_Periodos apiperiodo = new Api_Periodos();
                List<Periodoconsulta> ListaPeriodos = new List<Periodoconsulta>();
                ListaPeriodos = apiperiodo.ListarPeriodosOrdenados();
                int yearperiodo = int.Parse(DropDownListYear.SelectedValue);
                DropDownListPeriodo.Items.Clear();

                foreach (var item in ListaPeriodos)
                {
                    if (item.Anno == yearperiodo)
                    {
                        DropDownListPeriodo.Items.Add(item.NumeroPeriodo.ToString());

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

        protected void DropDownListNombreProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownListNombreProfesor.Items.Remove("seleccione un profesor");
                string id = DropDownListNombreProfesor.SelectedValue;
                Api_Profesores ApiProfesores = new Api_Profesores();
                List<profesorConsulta> ListaProf = new List<profesorConsulta>();
                ListaProf = ApiProfesores.ListarTodosProfesor();
                foreach (var item in ListaProf)
                {
                    if (item.Identificacion == id)
                    {
                        txt_identifiacion.Value = item.Identificacion;
                        txt_primerApellido.Value = item.PrimerApellido;
                        txt_segudoApellido.Value = item.SegundoApellido;
                        txt_tipoid.Value = item.TipoId;

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