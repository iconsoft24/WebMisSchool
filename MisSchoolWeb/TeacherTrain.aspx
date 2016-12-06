<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="TeacherTrain.aspx.vb" Inherits="MisSchoolWeb.TeacherTrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">
    


    <%--แสดงข้อมูล--%>
    <asp:GridView ID="TeacherTrainGV" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"   >
    
           <Columns>
                  <asp:BoundField DataField="termyear" HeaderText="ปี" >
<ControlStyle CssClass="gv1"></ControlStyle>
                  <HeaderStyle CssClass="gv1" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                  </asp:BoundField>
               <%--   <asp:BoundField DataField="year" HeaderText="ปี"/>--%>
                  <asp:BoundField DataField="Course" HeaderText="หลักสูตรที่อบรม"  >
<ControlStyle CssClass="gv1"></ControlStyle>
                  <HeaderStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="AddressCourse" HeaderText="สถานที่อบรม"  >
<ControlStyle CssClass="gv1"></ControlStyle>
                  <HeaderStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="DateCourse" HeaderText="วันที่อบรม" >
<ControlStyle CssClass="gv1"></ControlStyle>
                  <HeaderStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="TotalTimeCourse" HeaderText="จำนวนชั่วโมง"  >

<ControlStyle CssClass="gv1"></ControlStyle>
                  <HeaderStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                 <asp:CommandField  EditText="แก้ไข"  UpdateText="ตกลง" CancelText ="ยกเลิก" ButtonType="Button"  ShowEditButton="True"   /> 
          
            </Columns>

  
    
           <FooterStyle BackColor="White" ForeColor="#000066" />
           <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"   CssClass="gv1" />
           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
           <RowStyle ForeColor="#000066" />
           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F1F1F1" />
           <SortedAscendingHeaderStyle BackColor="#007DBB" />
           <SortedDescendingCellStyle BackColor="#CAC9C9" />
           <SortedDescendingHeaderStyle BackColor="#00547E" />

  
    
    </asp:GridView>
    <div>
</div>


   <div>   <a href ="TeacherTraining.aspx"><input id="Button1" type="button" value="เพิ่มข้อมูลการอบรม" class="btn btn-info" /></a> </div>


</asp:Content>
