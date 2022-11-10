<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesores_.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.Profesores_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" href="../CSS/Estilos_Prof_Est.css" />
    <title></title>
</head>
<body>
     <h1>Profesores</h1>
    <form id="form1" runat="server">
        <div>
              <label>Tipo de Identificación></label> 
             <input type="text" id="txt_tipoId"  placeholder="Tipo Identificación" runat="server"  maxlength="25"/>  
             <br />
            <label>Identificación</label>
           <input type="text" id="txt_identificaci"  placeholder="Numero de Identificación" runat="server"  maxlength="30"/>
            <br />
             <label>Nombre</label>
           <input type="text" id="txt_nombre"  placeholder="Nombre" runat="server"  maxlength="20"/>
    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="BTN" OnClick="BtnBuscar_Click" />
    <asp:Button ID="BtnBorrarFiltro" runat="server" Text="Borrar Filtro" OnClick="BtnBorrarFiltro_Click" />
       <asp:HiddenField ID="Codi" runat="server"/>  
    <asp:GridView ID="GridViProfesores" runat="server" OnRowCommand="GridViProfesores_RowCommand">
          <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="Smaller" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
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

    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar Profesor" OnClick="BtnAgregar_Click" />
    
   






        </div>
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