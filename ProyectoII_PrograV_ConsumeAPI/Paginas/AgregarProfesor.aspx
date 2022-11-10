<%@ Page Title="Agregar Profesor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProfesor.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.AgregarProfesor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <link rel="stylesheet" href="../CSS/EstilosFormularios.css" />

      
        <div>
             <h2>Ingreso de Profesor </h2>
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
            <asp:Button ID="btn_GuardarEstudia" runat="server" Text="Crear Profesor" OnClick="btn_GuardarEstudia_Click" />
             <button type="reset"> Limpiar </button>
            <br />
        </div>




</asp:Content>
