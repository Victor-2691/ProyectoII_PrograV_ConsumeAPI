<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.Cursos" EnableEventValidation="false" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://bootswatch.com/4/minty/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
          <link rel="stylesheet" href="../CSS/Estilos_Prof_Est.css" />
    <title>Cursos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <h1>Cursos</h1>
                     <asp:HiddenField ID="Codi" runat="server"/> 
    <asp:GridView ID="GriedvCursos" runat="server" OnRowCommand="GriedvCursos_RowCommand">
       
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="Smaller" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
         <Columns >

                    <asp:TemplateField ShowHeader="true" >
                        <ItemTemplate>

                           <asp:Button CssClass="btnEnlace" runat="server" Text="Actualizar" CommandName="Actualiza" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>                  
                          
                           <asp:Button CssClass="btnEnlaceEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return Confirmar();"/>
     
                        </ItemTemplate>          
                     </asp:TemplateField> 
                </Columns>


    </asp:GridView>
        </div>
     <br />

<asp:Button ID="BtnAgrega" runat="server" Text="Agregar Curso" OnClick="BtnAgrega_Click" />  
    
    </form>
          
    
    
</body>
</html>


<script>
function Confirmar() {


    if (confirm("Esta seguro que desea eliminar este registro ?") == true) {// true indica yes

        /*.getElementById se encarga de obtener los id html en aspx 
         valor (es el id del HiddenField de c#) */

        /*Se le asigna el valor con value*/
        document.getElementById('Codi').value = 'si';
    }
    else {// false incia not
        document.getElementById('Codi').value = 'no';
    }       
}
</script>