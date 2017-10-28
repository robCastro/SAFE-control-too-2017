<%@ Page Title="Nuevo Departamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearDepartamento.aspx.cs" Inherits="SistemaRiesgo.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Page.Title%></h3>
    <table class="table table-striped table-hover ">
        <tr>
            <td><asp:Label ID="LabelAddName" runat="server">Nombre</asp:Label></td>
            <td>
                <asp:TextBox ID="NombreDepartamento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Se requiere nombre para Departamento." ControlToValidate="NombreDepartamento" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>  
    </table>
    <p></p>
    <p></p>
    <table style="width:250px;">
        <tr>
            <td  >
                <div style="text-align:center">
                <asp:Button ID="btnGuardarYNuevoDepartamento" runat="server" Text="Guardar y Nuevo" OnClick="btnGuardarYNuevoDepartamento_Click"  CausesValidation="true" CssClass="btn btn-primary btn-sm"/>
                </div>
            </td>
            
        
            <td>
                
                <asp:Button ID="btnGuardarDepartamento" runat="server" Text="Guardar" OnClick="btnGuardarDepartamento_Click"  CausesValidation="true" CssClass="btn btn-primary btn-sm"/>
            </td>
        
    </table>
    

    <br />
    <br />
    <asp:Label ID="lblStatus" runat="server" Text="" ></asp:Label>
    <p></p>
</asp:Content>
