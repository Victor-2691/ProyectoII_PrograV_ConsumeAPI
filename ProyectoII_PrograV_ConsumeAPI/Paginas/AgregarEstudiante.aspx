<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarEstudiante.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.AgregarEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <link rel="stylesheet" href="../CSS/Estilos.css" />
    <title>Ingresa Estudiantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Ingreso de Estudiante </h2>
            <br />
            <br />
              <label>Tipo de Identificaciónlabel></label> 
             <input type="text" id="txt_tipoId"  placeholder="Tipo Identificación" runat="server" required="required" maxlength="25"/>  
             <br />
            <label>Identificación</label>
           <input type="text" id="txt_identificaci"  placeholder="Numero de Identificación" runat="server" required="required" maxlength="30"/>
            <br />
             <label>Nombre</label>
           <input type="text" id="txt_nombre"  placeholder="Nombre" runat="server" required="required" maxlength="20"/>
            <br />
           <label>Primer Apellido</label>
           <input type="text" id="txt_PrimerApellido"  placeholder="Primer Apellido" runat="server" required="required" maxlength="20"/>
            <br />
             <label>Segundo Apellido</label>
           <input type="text" id="txt_segundoApellido"  placeholder="Segundo Apellido" runat="server" required="required" maxlength="20"/>
              <br />
           <label>Fecha Nacimiento</label>
            <input type="date" id="txt_fecha"  runat="server" required="required"/>
             <br />
            <label >Correos Electrónicos</label>
            <textarea id="txt_Correos" runat="server" placeholder="ingrese los correos electronicos" required="required"></textarea>
             <br />
            <label>  Numeros de Telefono</label>
            <textarea id="txt_Numtelefonos" runat="server" placeholder="ingrese los numereros de telefono" required="required"></textarea>
       
            <br />
            <asp:Button ID="btn_GuardarEstudia" runat="server" Text="Crear Estudiante" OnClick="btn_GuardarEstudia_Click" />
             <button type="reset"> Limpiar </button>
            <br />
          



        </div>
    </form>
</body>
</html>
