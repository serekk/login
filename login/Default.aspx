<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="login._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
            <asp:BoundField DataField="haslo" HeaderText="haslo" SortExpression="haslo" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [uzytkownicy]"></asp:SqlDataSource>

    <asp:TextBox ID="TextBox1" runat="server" placeholder="login" Height="18px" Width="101px"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" placeholder="hasło" Height="18px" Width="101px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Zaloguj" OnClick="Button1_Click1"/>


</asp:Content>
