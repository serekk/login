<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="login._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
            <asp:BoundField DataField="haslo" HeaderText="haslo" SortExpression="haslo" />
            <asp:BoundField DataField="pytanie" HeaderText="pytanie" SortExpression="pytanie" /> 
            <asp:BoundField DataField="odpowiedz" HeaderText="odpowiedz" SortExpression="odpowiedz" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [uzytkownicy]"></asp:SqlDataSource>
        
    
    <h1>Login</h1>
    <asp:TextBox ID="TextBox1" runat="server" placeholder="login" Height="18px" Width="101px"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" placeholder="hasło" Height="18px" Width="101px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Zaloguj" OnClick="Button1_Click1"/>
    <br />
    <h1>Rejestracja</h1>
    <asp:TextBox ID="TextBoxRegisterLogin" runat="server" placeholder="login" Height="18px" Width="101px"></asp:TextBox>        
    <asp:TextBox ID="TextBoxRegisterPassword" runat="server" placeholder="hasło" Height="18px" Width="101px"></asp:TextBox>
    <asp:TextBox ID="TextBoxRegisterPasswordConfirmation" runat="server" placeholder="potwierdź hasło" Height="18px" Width="101px"></asp:TextBox>
    <asp:TextBox ID="TextBoxRegisterQuestion" runat="server" placeholder="pytanie" Height="18px" Width="101px"></asp:TextBox>
    <asp:TextBox ID="TextBoxRegisterAnwser" runat="server" placeholder="odpowiedź" Height="18px" Width="101px"></asp:TextBox>
    <asp:Button ID="ButtonRegister" runat="server" Text="Zarejestruj" OnClick="ButtonRegister_Click1"/>
    <br />
    <h1>Przypomnij hasło</h1>
    <asp:TextBox ID="TextBoxRecoveryLogin" runat="server" placeholder="login" Height="18px" Width="101px"></asp:TextBox>        
    <asp:TextBox ID="TextBoxRecoveryQuestion" runat="server" placeholder="pytanie" Height="18px" Width="101px"></asp:TextBox>        
    <asp:Button ID="ButtonRecovery" runat="server" Text="Resetuj hasło" OnClick="ButtonRecovery_Click1"/>


</asp:Content>
