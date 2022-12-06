<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarGrupo.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.AgregarGrupo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../CSS/EstilosFormularios.css" />
    <title>Agregar Grupo</title>
</head>
<body>
    <form id="form1" runat="server">
     <h2>Ingreso de Grupos</h2>

              <label>Numero Grupo</label> 
             <input type="number" id="txt_numgrupo"  placeholder="numero grupo" runat="server" required="required" />  
             <br />
            <label>Curso</label>
        <asp:DropDownList ID="DropDownListCursos" runat="server"></asp:DropDownList>
            <br />
                <label>Año Periodo</label>
        <asp:DropDownList ID="DropDownListYear" runat="server" OnSelectedIndexChanged="DropDownListYear_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList>
            <br />

                        <label>Numero Periodo</label>
        <asp:DropDownList ID="DropDownListPeriodo" runat="server" AutoPostBack="True"></asp:DropDownList>
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
        <input type="hidden" id="txt_tipoid" runat="server" />       
        <br />
         
            <asp:Button ID="btn_GuardarEstudia" runat="server" Text="Agregar Periodo" OnClick="btn_GuardarEstudia_Click" />
             <button type="reset"> Limpiar </button>
               <a href="GruposPrincipal.aspx"> <img src="../imagenes/atras (1).png" alt="icono" />  </a>
            <br />
        
    </form>
</body>
</html>
