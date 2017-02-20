<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="Studentinrow.aspx.vb" Inherits="MisSchoolWeb.Studentinrow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(function () {
            $("#dateinput").datepicker({
                dateFormat: "dd/mm/yy",
                monthNames: ['มกราคม', 'กุมภาพันธ์', 'มีนาคม', 'เมษายน', 'พฤษภาคม', 'มิถุนายน', 'กรกฎาคม', 'สิงหาคม', 'กันยายน', 'ตุลาคม', 'พฤศจิกายน', 'ธันวาคม'],
                dayNamesMin:['อา','จ','อ','พ','พฤ','ศ','ส']
            });
            $("#dateinput").datepicker("setDate", new Date());
        });


  //      {
  //    $("#dateinput").datepicker();
  //    $("#dateinput").datepicker("setDate", new Date());
  //    dateFormat: "dd/mm/yy";
  //} );
        </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">

Date:<asp:TextBox ID="dateinput"  runat="server"   ClientIDMode ="Static"></asp:TextBox>


    <asp:GridView ID="stdRowGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate >
                    <asp:CheckBox ID="cbrow" runat="server" Checked="True"  data-toggle="toggle"/>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="No_Room" HeaderText="เลขที่" />
            <asp:BoundField DataField="stdno" HeaderText="รหัสนักเรียน"  />
            <asp:BoundField DataField="Stdname" HeaderText="ชื่อ-นามสกุล" />
            <asp:ImageField>
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    <div> <asp:Button ID="Button1" runat="server" Text="Button"  /></div>
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbldateinput" runat="server" Text="Label"></asp:Label>
    <%--  --%>
</asp:Content>
