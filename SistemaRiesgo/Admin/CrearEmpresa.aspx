<%@ Page Title="Mi Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEmpresa.aspx.cs" Inherits="SistemaRiesgo.Admin.CrearEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="text-success text-align=right" ></asp:Label>
    <table>
        <tr>
            <td><h3><%: Page.Title %></h3></td>
            <td>          </td>
            <td></td>
        </tr>
    </table>
    
    <table class="table table-striped table-hover ">
        <tr>
            <td><asp:Label ID="Label1" runat="server">Nombre</asp:Label></td>
            <td>
                <asp:Label ID="nombreAnterior" CssClass="text-muted" runat="server"></asp:Label>
                <br />
                <asp:TextBox ID="NombreEmpresa" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Se requiere nombre para Departamento." ControlToValidate="NombreEmpresa" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label2" runat="server">Objetivos</asp:Label></td>
            <td>
                <asp:Label ID="objetivoAnterior" CssClass="text-muted" runat="server"></asp:Label>
                <br />
                <asp:TextBox ID="objetivos" TextMode="MultiLine" Columns="40" Rows="5" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label3" runat="server">Alcance</asp:Label></td>
            <td>
                <asp:Label ID="alcanceAnterior" runat="server" CssClass="text-muted"></asp:Label>
                <br />
                
                <asp:TextBox ID="alcance" TextMode="MultiLine" Columns="40" Rows="5" runat="server"></asp:TextBox>
            </td>
        </tr>
          
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="btnNuevaEmpresa" runat="server" Text="Guardar" OnClick="btnNuevaEmpresa_Click"  CausesValidation="true" CssClass="btn btn-primary btn-sm"/>
    <br />
    <br />
    
    <p></p>
</asp:Content>
