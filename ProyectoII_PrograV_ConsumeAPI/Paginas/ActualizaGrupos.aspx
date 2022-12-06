<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaGrupos.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.ActualizaGrupos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="../CSS/EstilosFormularios.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <h2>Actualiza Grupos</h2>

              <label>Numero Grupo</label> 
             <input type="text" id="txt_numgrupo" runat="server" readonly="true" />  
             <br />
                  <label>Codigo Curso</label> 
             <input type="text" id="txt_codigocurso" runat="server" readonly="true" />  
            <br />
                      <label>Nombre Curso</label> 
             <input type="text" id="txt_nombrecurso" runat="server" readonly="true" />  
            <br />
                    <label>Horario</label>
        <asp:DropDownList ID="DropDownListHorario" runat="server"></asp:DropDownList>

       <br />
          <label>Nombre Profesor</label>
        <asp:DropDownList ID="DropDownListNombreProfesor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListNombreProfesor_SelectedIndexChanged"></asp:DropDownList>
               <br />
        <label>Primer Apellido</label>
        <input type="text" id="txt_primerApellido" readonly="true" runat="server" />
             <br />
             <label>Segundo Apellido</label>
        <input type="text" id="txt_segudoApellido" readonly="true" runat="server" required="required" />
        <br />          
        <label>Numero de indentificación</label>
        <input type="text" id="txt_identifiacion" readonly="true" runat="server" required="required" />
            
        <br />
        <input type="hidden" id="txt_tipoid" runat="server" />  
        <input type="hidden" id="txt_year" runat="server" />
        <input type="hidden" id="txt_numeroperiodo" runat="server" />  
         
            <asp:Button ID="btn_actualiza" runat="server" Text="Actualizar Grupo" OnClick="btn_actualiza_Click" />
             <button type="reset"> Limpiar </button>
               <a href="GruposPrincipal.aspx"> <img src="../imagenes/atras (1).png" alt="icono" />  </a>
            <br />
        




    </form>
</body>
</html>
