<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCursos.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.AgregarCursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../CSS/Estilos.css" />
    <title>Ingresa Curso</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Ingreso de Curso Nuevo </h2>
            <br />
            <br />
              <label>Codigo de Curso</label> 
             <input type="text" id="Codigo_Curso"  placeholder="Codigo de Curso" runat="server" required="required" maxlength="10"/>  
             <br />
            <label>Nombre del Curso</label>
           <input type="text" id="Nombre_Curso"  placeholder="Nombre del Curso" runat="server" required="required" maxlength="30"/>
            <br />
            <label>Codigo de Carrera</label> 
             <input type="text" id="Codigo_Carrera"  placeholder="Codigo de Carrera" runat="server" required="required" maxlength="10"/>  
             <br />
            <br />
            <asp:Button ID="btn_GuardarCarrera" runat="server" Text="Crear Carrera" OnClick="btn_GuardarCarrera_Click" />
                
            <br />
            <asp:Button ID="Btn_Regresar" runat="server" Text="Cancelar" OnClick="Btn_Regresar_Click" />



        </div>
    </form>
</body>
</html>