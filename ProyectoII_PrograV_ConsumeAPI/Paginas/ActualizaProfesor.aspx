<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizaProfesor.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.ActualizaProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../CSS/EstilosFormularios.css" />
    <h2>Actualiza Profesor </h2>
            <br />
            <br />
              <label>Tipo de Identificaciónlabel></label> 
             <input type="text" id="txt_tipoId" runat="server"   readonly="true"/>  
             <br />
            <label>Identificación</label>
           <input type="text" id="txt_identificaci" runat="server"  readonly="true"/>
            <br />
             <label>Nombre</label>
           <input type="text" id="txt_nombre"  placeholder="Nombre" runat="server" required="required" maxlength="20"/>
            <br />
           <label>Primer Apellido</label>
           <input type="text" id="txt_PrimerApellido"  placeholder="Primer Apellido" runat="server"  required="required" maxlength="20"/>
            <br />
             <label>Segundo Apellido</label>
           <input type="text" id="txt_segundoApellido"  placeholder="Segundo Apellido" runat="server" required="required" maxlength="20"/>
              <br />
           <label>Fecha Nacimiento</label>
            <input type="date" id="txt_fecha"  runat="server" required="required" value="1999-01-01" />
      <br />
            <asp:Button ID="Btnactualizar" runat="server" Text="Actualizar" OnClick="Btnactualizar_Click" />
            <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" OnClick="BtnRegresar_Click" />
            <br />



</asp:Content>
