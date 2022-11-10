<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaCursos.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.ActualizaCursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
            <link rel="stylesheet" href="../CSS/Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
                     <h2>Actualiza Curso</h2>
            <br />
            <br />
              <label>Codigo de Curso</label> 
             <input type="text" id="txtCodigo_Curso"  placeholder="Codigo de Curso" runat="server" readonly="true"/>  
             <br />
            <label>Nombre del Curso</label>
           <input type="text" id="txtNombre_Curso"  placeholder="Nombre del Curso" runat="server" required="required" maxlength="30"/>
            <br />
            <label>Codigo de Carrera</label> 
             <input type="text" id="txtCodigo_Carrera"  placeholder="Codigo de Carrera" runat="server" readonly="true"/>  
             <br />
            <br />
            <asp:Button ID="btn_GuardarCarrera" runat="server" Text="Actualizar Curso" OnClick="btn_GuardarCarrera_Click" />
                
            <br />
            <asp:Button ID="Btn_Regresar" runat="server" Text="Regresar" OnClick="Btn_Regresar_Click" />

        </div>
    </form>
</body>
</html>
