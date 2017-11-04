<%@ Page Title="Lista de Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEmpleados.aspx.cs" Inherits="SistemaRiesgo.GestionarEmpleado.ListaEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <h2><%: Page.Title %></h2>
            <asp:Label ID="accion" Text="" runat="server" CssClass="text-info"/>
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" CssClass="text-danger" />
        </div>
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource1" Width="600px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" SortExpression="idUsuario" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button4" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button5" runat="server" CausesValidation="False" CommandName="Select" Text="Select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:edwin %>" 
                SelectCommand="SELECT [codigo], [nombre], [idUsuario] FROM [Empleadoes] WHERE ([departamento_codigo] = @departamento_codigo)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="departamento_codigo" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </section>
    <br />
    <asp:Label ID="codSec" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <div>
            <asp:Button ID="ReturnDepto" runat="server" Visible="true" Text="Retornar a Departamentos" OnClick="ReturnD_Click" />
            <asp:HyperLink ID="btnNuevo" NavigateUrl="CrearEmpleado" Text="Nuevo Empleado" runat="server" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="GPermit" runat="server" Visible="false" Text="Gestionar Permisos" OnClick="GPermit_Click" />
        </div>
</asp:Content>
