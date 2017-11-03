<%@ Page Title="Permisos Locales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarPermisosD.aspx.cs" Inherits="SistemaRiesgo.GestionarEmpleado.GestionarPermisosD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3 style="text-align:center;"><asp:Label ID="lblUsuarioInvalido"  Text="Id de Usuario Invalido" runat="server" Visible="false" CssClass="text-danger" /></h3>
    
    
    <asp:Label Text="" ID="msjExito" CssClass="text-success" runat="server" />
    <asp:Label Text="" ID="msjError" CssClass="text-danger" runat="server" />
    

    
    <h3 id="divNombreEmpleado" runat="server">
        Empleado: <asp:Label ID="lblNombreEmpleado" Text="" runat="server" /> 
    </h3>
    
    <br /><br /><br />
    
    <div id="permisos" style="text-align:center">
        <table id="tablaPermisos" runat="server">
            <tr>
                <td style="width:300px; text-align:left"></td> 
                
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="ejecutarTar" Text="Ejecutar Tareas" TextAlign="Right" runat="server"  />
                </td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="registrarAct" Text="Registrar Activos" TextAlign="Right" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width:300px; text-align:left"></td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="confirmarEjec" Text="Confirmar Ejecucion de Tareas" TextAlign="Right" runat="server" />
                </td>
                <td style="width:250px; text-align:left">
                    <asp:CheckBox ID="administrarEmp" Text="Administrar Empleados" TextAlign="Right" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width:300px; text-align:left"></td>
                <td style="width:400px; text-align:left">
                    <asp:CheckBox ID="decidirRiesgo" Text="Tomar Decisión sobre Riesgo" TextAlign="Right" runat="server" />
                </td>
                <td style="width:250px; text-align:left">
                    <asp:CheckBox ID="asignarTareas" Text="Asignar Tareas" TextAlign="Right" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br /><br />
    <table id="tablaBotones" runat="server">
        <tr>
            <td>
                <div id="botonGuardar" style="width:200px; text-align:center">
                    <asp:Button Text="Guardar" CssClass="btn btn-primary btn-sm" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" />
                </div>
            </td>
            <td>
                <div id="botonCancelar" style="width:150px; text-align:left">
                    <asp:Button Text="Cancelar" CssClass="btn btn-primary btn-sm" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click"/>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br /><br />
                <asp:LinkButton Text="Volver a Empleados" runat="server" OnClick="btnCancelar_Click" CssClass="text-muted" />
            </td>
        </tr>
    </table>
</asp:Content>
