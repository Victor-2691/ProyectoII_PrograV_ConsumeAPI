<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarperiodo.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.agregarperiodo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="../CSS/EstilosFormularios.css" />
           <script src="../JavaScript/GestionOperaciones.js"></script>
    <title>Agregar Periodos</title>
</head>
<body>
    <div>
    <form id="form1" runat="server" class="formulario">
              <h2>Ingreso de Periodos </h2>

              <label>Año periodo</label> 
             <input type="number" id="txt_year"  placeholder="Año periodo" runat="server" required="required" max="2025" min="2018" />  
             <br />
            <label>Numero Periodo</label>
   
        <asp:DropDownList ID="DropDownListPeriodo" runat="server"></asp:DropDownList>
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
            <asp:Button ID="btn_GuardarEstudia" runat="server" Text="Crear Periodo" OnClick="btn_GuardarEstudia_Click" />
             <button type="reset"> Limpiar </button>
               <a href="Periodo_Principal.aspx"> <img src="../imagenes/atras (1).png" alt="icono" />  </a>
            <br />
        
    </form>
        </div>

        
</body>
</html>
