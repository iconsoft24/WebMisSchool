<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="TeacherTrain.aspx.vb" Inherits="MisSchoolWeb.TeacherTrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">
    <asp:GridView ID="TeacherTrainGV" runat="server" AutoGenerateColumns="False" CellPadding="4"
         ForeColor="#333333" GridLines="None">
    
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
           <Columns>
                  <asp:BoundField DataField="term" HeaderText="เทอม"/>
                  <asp:BoundField DataField="year" HeaderText="ปี"/>
                  <asp:BoundField DataField="Course" HeaderText="หลักสูตรที่อบรม"/>
                  <asp:BoundField DataField="AddressCourse" HeaderText="สถานที่อบรม"/>
                  <asp:BoundField DataField="DateCourse" HeaderText="วันที่อบรม"/>
                  <asp:BoundField DataField="TotalTimeCourse" HeaderText="จำนวนชั่วโมง"/>
            </Columns>

              
           <EditRowStyle BackColor="#999999" />

              
           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#E9E7E2" />
           <SortedAscendingHeaderStyle BackColor="#506C8C" />
           <SortedDescendingCellStyle BackColor="#FFFDF8" />
           <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

              
    </asp:GridView>
</asp:Content>
