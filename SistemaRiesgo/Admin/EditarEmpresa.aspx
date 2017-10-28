<%@ Page Title="Editar Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="SistemaRiesgo.Admin.EditarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <div>
            <h2><%: Page.Title %></h2>
            <asp:Label ID="accion" Text="" runat="server" CssClass="text-info"/>
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" CssClass="text-danger" />
            <asp:GridView ID="miEmpresa" runat="server" 
                ItemType="SistemaRiesgo.Models.Empresa" DataKeyNames="codigo"
                SelectMethod="miEmpresa_GetData"
                UpdateMethod="miEmpresa_UpdateItem"
                AutoGenerateEditButton="true"
                AutoGenerateColumns="false"
                CssClass ="table table-striped table-hover"
                BorderStyle ="Solid"
                BorderColor="WhiteSmoke"
                >
                
                <Columns>

                    <asp:DynamicField ControlStyle-BorderColor="Black" DataField="nombre" />
                    <asp:DynamicField ControlStyle-BorderColor="Black" DataField="objetivos" />
                    <asp:DynamicField ControlStyle-BorderColor="Black" DataField="alcance" />
                </Columns>
                
            </asp:GridView>
        </div>
    </section>

</asp:Content>
