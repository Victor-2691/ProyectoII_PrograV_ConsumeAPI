<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaCarreras.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.ActualizaCarreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <link rel="stylesheet" href="../CSS/Estilos.css" />
    <title>Actualizar Carreras</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <h2>Actualizar Carrera </h2>
            <br />
            <br />
              <label>Codigo de Carrera</label> 
             <input type="text" id="txtCodigo_Carrera"  placeholder="Codigo de Carrera" runat="server" readonly="true"/>  
             <br />
            <label>Nombre de la Carrera</label>
           <input type="text" id="txtNombre_Carrera"  placeholder="Nombre de la Carrera" runat="server" required="required" maxlength="30"/>
            <br />
           
            <br />
            <asp:Button ID="btn_GuardarCarrera" runat="server" Text="Actualizar Carrera" OnClick="btn_GuardarCarrera_Click" />
                
            <br />
            <asp:Button ID="Btn_Regresar" runat="server" Text="Regresar" OnClick="Btn_Regresar_Click" />
        </div>
    </form>
</body>
</html>
