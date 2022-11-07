<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiantes_.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.Estudiantes_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <h1>Estudiantes</h1>
    <asp:GridView ID="GriedvEstudiantes" runat="server">
             <Columns>
            <asp:CommandField HeaderText="Selección" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="Smaller" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        </div>
   <br />
   <br />
     <br />

 <asp:Button ID="BtnAgrega" runat="server" Text="Agregar Estudiante" OnClick="BtnAgrega_Click" />    
    
    </form>
          
    
    
</body>
</html>
