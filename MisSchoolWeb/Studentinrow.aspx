<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="Studentinrow.aspx.vb" Inherits="MisSchoolWeb.Studentinrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">
    <asp:GridView ID="stdRowGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate ><asp:CheckBox ID="cb" runat="server" Checked="True" /></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="No_Room" HeaderText="เลขที่" />
            <asp:BoundField DataField="stdno" HeaderText="รหัสนักเรียน" />
            <asp:BoundField DataField="Stdname" HeaderText="ชื่อ-นามสกุล" />
            <asp:ImageField>
            </asp:ImageField>
        </Columns>
    </asp:GridView>
        

</asp:Content>
