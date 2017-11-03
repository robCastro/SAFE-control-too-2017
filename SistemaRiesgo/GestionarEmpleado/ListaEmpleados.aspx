<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEmpleados.aspx.cs" Inherits="SistemaRiesgo.GestionarEmpleado.ListaEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <h2><%: Page.Title %></h2>
            <asp:Label ID="accion" Text="" runat="server" CssClass="text-info"/>
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" CssClass="text-danger" />
            <br />
            <br />
            <asp:TextBox ID="TextBoxDepto" runat="server" Visible="false" Text="0"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="NoDepto" runat="server" Text="No hay departamento registrados" Visible="false"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource1" Width="649px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                    <asp:ControlParameter ControlID="TextBoxDepto" Name="departamento_codigo" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="GPermit" runat="server" Visible="false" Text="Gestionar Permisos" OnClick="GPermit_Click" />
            <asp:HyperLink ID="btnNuevo" NavigateUrl="CrearEmpleado" Text="Nuevo Empleado" runat="server" CssClass="btn btn-primary btn-sm" />
        </div>
    </section>
</asp:Content>
