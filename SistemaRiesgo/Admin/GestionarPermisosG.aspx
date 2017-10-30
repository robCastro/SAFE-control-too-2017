<%@ Page Title="Permisos Globales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarPermisosG.aspx.cs" Inherits="SistemaRiesgo.Admin.GestionarPermisosG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3 style="text-align:center;"><asp:Label ID="lblUsuarioInvalido"  Text="Id de Usuario Invalido" runat="server" Visible="false" CssClass="text-danger" /></h3>
    
    
    <asp:Label Text="" ID="msjAuxiliar" runat="server" />
    <asp:Label Text="" ID="msjAuxiliar2" runat="server" />
    
    <h3 id="divNombreEmpleado" runat="server">
        Nombre: <asp:Label ID="lblNombreEmpleado" Text="" runat="server" /> 
    </h3>
    
    <br /><br /><br />
    
    <div id="permisos" style="text-align:center">
        <table id="tablaPermisos" runat="server">
            <tr>
                <td style="width:300px; text-align:left"></td> 
                
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="clasificarActivos" Text="Clasificar Activos" TextAlign="Right" runat="server" OnCheckedChanged="clasificarActivos_CheckedChanged" />
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
                    <asp:CheckBox ID="asignarPlan" Text="Asignar Plan" TextAlign="Right" runat="server" OnCheckedChanged="asignarPlan_CheckedChanged" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br /><br />
    <table id="tablaBotones" runat="server">
        <tr>
            <td>
                <div id="botonGuardar" style="width:200px; text-align:center">
                    <asp:Button Text="Guardar"  runat="server" OnClick="btnGuardarClic"/>
                </div>
            </td>
            <td>
                <div id="botonCancelar" style="width:150px; text-align:left">
                    <asp:Button Text="Cancelar"  runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
