<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Periodo_Principal.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.Periodo_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        
    <link rel="stylesheet" href="../CSS/styles.css" />
       <script src="../JavaScript/GestionOperaciones.js"></script>

    <title>Periodos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Periodos</h1>
       <div class="contenedor_periodos">
           <div class="contenedor_tablaperiodos">
         <asp:HiddenField ID="Codi" runat="server"/>   
               <asp:GridView ID="GridPeriodo" runat="server" CssClass="gridPeriodo" OnRowCommand="GridPeridos_RowCommand">
                        <Columns >

                    <asp:TemplateField ShowHeader="true" >
                        <ItemTemplate>

                           <asp:Button CssClass="btnGrid" runat="server" Text="Actualizar" CommandName="Actualiza" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>                  
                          
                           <asp:Button CssClass="btnGrid" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return Confirmar();"/>
     
                        </ItemTemplate>          
                     </asp:TemplateField> 
                </Columns>



               </asp:GridView>

           </div>

           <div class="contenedor_btn">
               <asp:Button CssClass="btnInput" runat="server" Text="Agregar Periodo" OnClick="Btnagrega_Click" />
               <br />
               <br />
               <a class="regresa" href="../Default.aspx"> <img src="../imagenes/atras (1).png" alt="icono" />  </a>


           </div>

              
       </div>
     





    </form>
</body>
</html>
