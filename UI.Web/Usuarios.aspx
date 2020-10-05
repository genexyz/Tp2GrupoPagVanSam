<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="ContentUsuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Usuarios:</h2><br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
            SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
            <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar   |    </asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar      | </asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo     |   </asp:LinkButton>
            <asp:LinkButton ID="asignarPermisosLinkButton" runat="server">     Asignar Permisos</asp:LinkButton>
        </asp:Panel>
    <br />
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Nombre de Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" 
                ErrorMessage="El campo Nombre de Usuario es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
            <br />
            <asp:LinkButton ID="seleccionarPersonaLabel" runat="server" onclick="seleccionarPersonaLabel_Click" 
                 CausesValidation="False">Seleccionar Persona  </asp:LinkButton>
            <asp:TextBox ID="personaTextBox" runat="server" Enabled="False" Width="173px">--Persona no seleccionada--</asp:TextBox>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="claveTextBox" Display="Dynamic" 
                ErrorMessage="El campo Clave es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
            <br />
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <%--<asp:CompareValidator ID="cvRepetirClave" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" 
                Display="Dynamic" ErrorMessage="Las claves deben coincidir" ForeColor="Red">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvRepetirClave" runat="server" ControlToValidate="repetirClaveTextBox" Display="Dynamic" 
                ErrorMessage="El campo Repetir Clave es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
            <asp:Panel ID="personasPanel" runat="server" Visible="False">
                <asp:GridView ID="dgvPersonas" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            onselectedindexchanged="dgvPersonas_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="TipoPersona" HeaderText="Tipo Persona" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
                <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
            </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="personasSelecPanel" runat="server" Visible="False">
        <asp:LinkButton ID="lbSeleccionar" runat="server" onclick="lbSeleccionar_Click">Seleccionar</asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" runat="server" onclick="lbCancelar_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
        </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar       </asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkbutton" runat="server" OnClick="cancelarLinkbutton_Click">Cancelar       </asp:LinkButton>
        <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="Red" />
    </asp:Panel>
</asp:Content>
