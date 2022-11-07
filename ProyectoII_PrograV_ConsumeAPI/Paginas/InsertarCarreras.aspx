<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarCarreras.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.InsertarCarreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../CSS/Estilos.css" />
    <title>Ingresa Carrera</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Ingreso de Carrera Nueva </h2>
            <br />
            <br />
              <label>Codigo de Carrera</label> 
             <input type="text" id="Codigo_Carrera"  placeholder="Codigo de Carrera" runat="server" required="required" maxlength="10"/>  
             <br />
            <label>Nombre de la Carrera</label>
           <input type="text" id="Nombre_Carrera"  placeholder="Nombre de la Carrera" runat="server" required="required" maxlength="30"/>
            <br />
           
            <br />
            <asp:Button ID="btn_GuardarCarrera" runat="server" Text="Crear Carrera" OnClick="btn_GuardarCarrera_Click" />
                
            <br />
            <asp:Button ID="Btn_Regresar" runat="server" Text="Cancelar" OnClick="Btn_Regresar_Click" />



        </div>
    </form>
</body>
</html>