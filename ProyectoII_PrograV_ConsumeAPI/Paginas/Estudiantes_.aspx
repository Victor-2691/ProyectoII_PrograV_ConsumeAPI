<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiantes_.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.Estudiantes_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

       <style>
                 .BTN {
                width: 150px;
               background-color: #4CAF50;
               color: white;
              padding: 14px 20px;
              margin: 8px 0;
             border: none;
             border-radius: 4px;
               cursor: pointer;
}

       BTN:hover {
        background-color: #45a049;
    }
             </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Estudiantes</title>
</head>

    <header>
                <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse" title="more options">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                  
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/">Inicio</a></li>
                           <li><a runat="server" href="~/Paginas/Estudiantes_.aspx">Estudiantes</a></li>
                              <li><a runat="server" href="~/Paginas/Carreras.aspx">Carreras</a></li>
                                   <li><a runat="server" href="~/Paginas/Cursos.aspx">Cursos</a></li>

                        <li><a runat="server" href="~/About">Acerca de</a></li>
                        <li><a runat="server" href="~/Contact">Contacto</a></li>
                    </ul>
                </div>
            </div>
        </div>

    </header>


<body>
    <form id="form1" runat="server">
        <div>
      <h1>Estudiantes</h1>
            <asp:GridView ID="GriedvEstudiantes" runat="server" DataKeyNames="TipoId,Identificacion" OnRowDeleting="GriedvEstudiantes_RowDeleting"  >
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="Smaller" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
          <Columns>
                <asp:CommandField HeaderText="Actualiza" ShowEditButton ="true" />
                </Columns>
                 <Columns>
                <asp:CommandField HeaderText="Elimina" ShowDeleteButton ="true" />
                </Columns>
    </asp:GridView>
        </div>
   <br />
   <br />
     <br />

 <asp:Button ID="BtnAgrega" runat="server" Text="Agregar Estudiante" OnClick="BtnAgrega_Click" CssClass="BTN" />    
    
    </form>
          
    
    
</body>

</html>

