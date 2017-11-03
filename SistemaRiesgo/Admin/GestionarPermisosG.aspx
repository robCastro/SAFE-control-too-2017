<%@ Page Async="true" Title="Permisos Globales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarPermisosG.aspx.cs" Inherits="SistemaRiesgo.Admin.GestionarPermisosG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3 style="text-align:center;"><asp:Label ID="lblUsuarioInvalido"  Text="Id de Usuario Invalido" runat="server" Visible="false" CssClass="text-danger" /></h3>
    
    
    <asp:Label Text="" ID="msjExito" CssClass="text-success" runat="server" />
    <asp:Label Text="" ID="msjAuxiliar2" CssClass="text-danger" runat="server" />
    

    
    <h3 id="divNombreEmpleado" runat="server">
        Empleado: <asp:Label ID="lblNombreEmpleado" Text="" runat="server" /> 
    </h3>
    
    <br /><br /><br />
    
    <div id="permisos" style="text-align:center">
        <table id="tablaPermisos" runat="server">
            <tr>
                <td style="width:300px; text-align:left"></td> 
                
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="clasificarActivos" Text="Clasificar Activos" TextAlign="Right" runat="server"  />
                </td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="asignarVuln" Text="Asignar Vulnerabilidades" TextAlign="Right" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width:300px; text-align:left"></td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="gestionarVuln" Text="Gestionar Vulnerabilidad" TextAlign="Right" runat="server" />
                </td>
                <td style="width:250px; text-align:left">
                    <asp:CheckBox ID="gestionarAmen" Text="Gestionar Amenaza" TextAlign="Right" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width:300px; text-align:left"></td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="gestionarPlan" Text="Gestionar Planes" TextAlign="Right" runat="server" />
                </td>
                <td style="width:250px; text-align:left">
                    <asp:CheckBox ID="asignarPlan" Text="Asignar Plan" TextAlign="Right" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br /><br />
    <table id="tablaBotones" runat="server">
        <tr>
            <td>
                <div id="botonGuardar" style="width:200px; text-align:center">
                    <asp:Button Text="Guardar" CssClass="btn btn-primary btn-sm" runat="server" OnClick="Unnamed_Click"/>
                </div>
            </td>
            <td>
                <div id="botonCancelar" style="width:150px; text-align:left">
                    <asp:HyperLink ID="linkListaDepartamentos" NavigateUrl="ListaDepartamentos" Text="Cancelar" runat="server" CssClass="btn btn-primary btn-sm" />
                </div>
            </td>
            
        </tr>
    </table>
    <br /><br />
    <a href="~/Admin/ListaDepartamentos" id="linkListaDep" class="text-muted" runat="server">Volver a Departamentos</a>
</asp:Content>
