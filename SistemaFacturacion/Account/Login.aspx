<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaFacturacion.Account.Login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="panel panel-default">
        <div class="panel-heading">
            <i class="fa  fa-sign-in fa-fw"></i>Usar Cuenta Proporcionada por la Compañia
        </div>
        <div class="panel-body">
            <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" FailureText="El inicio de sesión no se pudo realizar, favor de verificar.">
                <LayoutTemplate>
                    <p class="vlidation-summary-errors" style="color: red;">
                        <asp:Literal runat="server"  ID="FailureText" />
                    </p>

                    <asp:Label runat="server" AssociatedControlID="UserName">Nombre Usuario</asp:Label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="El nombre de Usario es requerido." ForeColor="Red" />
                    <asp:TextBox runat="server" ID="UserName" />


                    <asp:Label runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                    &nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="La contraseña es requerida." ForeColor="Red" />
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />


                    <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox-inline">
                        <asp:CheckBox runat="server" ID="RememberMe" />Recordame Aquí?
                    </asp:Label>
                    <br />
                    <br />
                    <asp:Button runat="server" CommandName="Login" CssClass="btn btn-lg btn-success btn-block" Text="Iniciar Sessión" />
                </LayoutTemplate>
            </asp:Login>

        </div>
    </div>


</asp:Content>
