<%@ Page Title="Lista de Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEmpleados.aspx.cs" Inherits="SistemaRiesgo.GestionarEmpleado.ListaEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <h2><%: Page.Title %></h2>
            <asp:Label ID="accion" Text="" runat="server" CssClass="text-info"/>
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" CssClass="text-danger" />
        </div>
        <div>
            <asp:Label ID="MsjError" runat="server" Text="No existe el Departamento" Visible="false"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource1" Width="850px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                CssClass ="table table-striped table-hover"
                BorderStyle ="Solid"
                BorderColor="WhiteSmoke">
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
                SelectCommand="SELECT [codigo], [nombre], [idUsuario] FROM [Empleadoes] WHERE ([departamento_codigo] = @departamento_codigo)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Empleadoes] WHERE [codigo] = @original_codigo AND [nombre] = @original_nombre AND (([idUsuario] = @original_idUsuario) OR ([idUsuario] IS NULL AND @original_idUsuario IS NULL))" InsertCommand="INSERT INTO [Empleadoes] ([nombre], [idUsuario]) VALUES (@nombre, @idUsuario)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Empleadoes] SET [nombre] = @nombre, [idUsuario] = @idUsuario WHERE [codigo] = @original_codigo AND [nombre] = @original_nombre AND (([idUsuario] = @original_idUsuario) OR ([idUsuario] IS NULL AND @original_idUsuario IS NULL))"
                >
                <DeleteParameters>
                    <asp:Parameter Name="original_codigo" Type="Int32" />
                    <asp:Parameter Name="original_nombre" Type="String" />
                    <asp:Parameter Name="original_idUsuario" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="idUsuario" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="departamento_codigo" PropertyName="Text" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="idUsuario" Type="String" />
                    <asp:Parameter Name="original_codigo" Type="Int32" />
                    <asp:Parameter Name="original_nombre" Type="String" />
                    <asp:Parameter Name="original_idUsuario" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </section>
    <br />
    <asp:Label ID="codSec" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <div>
            <asp:Button ID="ReturnDepto" runat="server" Visible="true" Text="Retornar a Departamentos" OnClick="ReturnD_Click" />
            <asp:Button ID="btnNuevoE" runat="server" Visible="true" Text="Nuevo Empleado" OnClick="NvoEmpleado" />
            <asp:Button ID="GPermit" runat="server" Visible="false" Text="Gestionar Permisos" OnClick="GPermit_Click" />
        </div>
</asp:Content>