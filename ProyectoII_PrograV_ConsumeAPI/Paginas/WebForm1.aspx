<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProyectoII_PrograV_ConsumeAPI.Paginas.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div>
      <h1>Estudiantes</h1>
                <asp:GridView ID="GriedvEstudiantes" runat="server" OnSelectedIndexChanged="GriedvEstudiantes_SelectedIndexChanged">
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
</asp:Content>

-