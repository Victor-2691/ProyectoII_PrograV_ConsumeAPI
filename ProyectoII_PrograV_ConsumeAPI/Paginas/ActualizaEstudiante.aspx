<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaEstudiante.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.ActualizaEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="../CSS/Estilos.css" />
    <title>Actualiza Estudiantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Actualiza Estudiante </h2>
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

       
            <br />
            <asp:Button ID="Btnactualizar" runat="server" Text="Actualizar" OnClick="Btnactualizar_Click" />
            <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" OnClick="BtnRegresar_Click" />
            <br />
        </div>
    </form>
</body>
</html>
