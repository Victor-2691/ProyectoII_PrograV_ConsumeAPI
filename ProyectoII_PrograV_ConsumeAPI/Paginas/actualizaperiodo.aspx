<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="actualizaperiodo.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.actualizaperiodo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../CSS/EstilosFormularios.css" />
           <script src="../JavaScript/GestionOperaciones.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <h2>Actualiza Periodos </h2>

              <label>Año periodo</label> 
             <input type="number" id="txt_year"  runat="server" readonly="true" />  
             <br />
            <label>Numero Periodo</label>
               <input type="text" id="txt_numeroperiodo"  runat="server" readonly="true" />  

            <br />
           <label>Fecha Inicio</label>
            <input type="date" id="txt_fecha_Inicio"  runat="server" required="required"/>
             <br />
                <label>Fecha Cierre</label>
            <input type="date" id="txt_fecha_cierre"  runat="server" required="required"/>
                  <br />
            <label>Estado Periodo</label>

        <asp:DropDownList ID="DropDownListEstadoPeriodo" runat="server"></asp:DropDownList>
       <br />
             <br />
            <asp:Button ID="btn_GuardarEstudia" runat="server" Text="Actualizar" OnClick="btn_GuardarEstudia_Click" />
   
               <a href="Periodo_Principal.aspx"> <img src="../imagenes/atras (1).png" alt="icono" />  </a>
            <br />
    </form>
</body>
</html>
