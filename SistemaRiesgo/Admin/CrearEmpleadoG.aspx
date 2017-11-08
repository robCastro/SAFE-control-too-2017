<%@ Page Title="Empleado Global" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEmpleadoG.aspx.cs" Inherits="SistemaRiesgo.Admin.CrearEmpleadoG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
        <tr>
            <td><h3 style="text-align:center"><%: Page.Title %></h3></td>
            <td>          </td>
            <td></td>
        </tr>
    </table>
    
  
   
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="NombreEmpleado" runat="server" CssClass="form-control" ></asp:TextBox>

            </div>
        </div>
    <br />
         <div class="form-group">
             <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Email</asp:Label>
             <div class="col-md-10">
                 <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="Se requiere un Email." />
             </div>

         </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Se requiere una contraseña." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>   
                
        <table>   
         <tr>
             <td>&nbsp;</td>
             
             <td>
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
                 <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button2"  runat="server" OnClick="Button2_Click" Text="Cancelar"  />
             </td>
                 
             </td>
         </tr>

     </table>
<asp:Label ID="lblStatus" runat="server" Text="" ></asp:Label>
      
     
</asp:Content>
  