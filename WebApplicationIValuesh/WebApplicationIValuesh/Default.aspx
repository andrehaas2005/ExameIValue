<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationIValuesh.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Exame I-Value – Desenvolvedor</title>
    <link href="App_Themes/Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
      <h1>Exame I-Value – Desenvolvedor</h1>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="arq" runat="server" accept=".txt" /><br />
            <asp:FileUpload ID="arq1" runat="server" accept=".txt" /><br />
            <asp:Button ID="btn_comparar" runat="server" OnClick="btn_comparar_Click" Text="Comparar" CssClass="but but-padrao" />
            <asp:Button ID="btn_limpar" runat="server" OnClick="btn_limpar_Click" Text="Limpar" CssClass="but but-padrao" />
        </div>
        <div id="divText1" class="outset" runat="server" style="display: none">
            <h2>
                <asp:Label ID="lb1" runat="server" Text=""></asp:Label></h2>
            <asp:TextBox runat="server" ID="TextBox1" Visible="false" TextMode="MultiLine" CssClass="grande" Enabled="false"></asp:TextBox>
            <h3>
                <asp:Label ID="lbResult" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbResultVerbetes" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <div id="divText2" class="outset" runat="server" style="display: none">

            <h2>
                <asp:Label ID="lb21" runat="server" Text=""></asp:Label></h2>
            <asp:TextBox runat="server" ID="TextBox2" Visible="false" TextMode="MultiLine" CssClass="grande" Enabled="false"></asp:TextBox>
            <h3>
                <asp:Label ID="lbResult2" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbResultVerbetes2" runat="server" Text=""></asp:Label>
            </h3>
        </div>
    </form>

</body>
</html>
