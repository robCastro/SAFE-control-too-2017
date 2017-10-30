<%@ Page Title="Crear Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEmpleado.aspx.cs" Inherits="SistemaRiesgo.Admin.CrearEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
        <tr>
            <td><h3 style="text-align:center"><%: Page.Title %></h3></td>
            <td>          </td>
            <td></td>
        </tr>
    </table>
    
    <table class="table table-striped table-hover ">
        <tr>
            <td><asp:Label ID="Label1" runat="server">Nombre</asp:Label></td>
            <td>
                <asp:TextBox ID="NombreEmpleado" runat="server"></asp:TextBox>
               
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server">Apellidos</asp:Label>
            </td>
             <td><asp:TextBox ID="ApellidoEmpleado" runat="server"></asp:TextBox></td>
            <td>
       
        </tr>
        
      
 </table>
    
        <table>   
         <tr>
             <td><asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Registrar" Width="200px"/></td>
             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
             <td><asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" Width="200px"/></td>
         </tr>

     </table>

      
     
</asp:Content>
  


