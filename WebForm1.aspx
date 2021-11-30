<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="vaccine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vaccination Survey</title>
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Alegreya Sans SC' rel='stylesheet' />
</head>
<body>
    <div class="userform">
        <form id="form1" runat="server">
        <div style="height: 468px; width: 591px">
            Name : <asp:TextBox ID="TextBox1" runat="server" style="margin-bottom: 0px" Width="220px"></asp:TextBox>
            <br />
            <br />
            Aadhar No : <asp:TextBox ID="TextBox2" runat="server" style="margin-bottom: 0px" Width="220px"></asp:TextBox>
            <br />
            <br />
            Vaccine :
            <asp:TextBox ID="TextBox3" runat="server" style="margin-bottom: 0px" Width="220px"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Dose 1" Checked="True" onclick="return false;"/>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Dose 2" />
            <br />
            Vaccine Certificate :&nbsp;&nbsp; <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="Button2_Click" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="searchText" runat="server">Enter Aadhar No.</asp:TextBox>
            <asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click1" Text="Search" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="581px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Aadhar_no" HeaderText="Aadhar No." />
                    <asp:BoundField DataField="vaccine_name" HeaderText="Vaccine" />
                    <asp:CheckBoxField DataField="dose1" HeaderText="Dose1" />
                    <asp:CheckBoxField DataField="dose2" HeaderText="Dose 2" />
                    <asp:CommandField CancelText="" DeleteText="" InsertText="" NewText="" SelectText="" ShowEditButton="True" UpdateText="" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
    </div>    
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>