<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="TeacherTraining.aspx.vb" Inherits="MisSchoolWeb.TeacherTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">

    
    <div class="row"> <%--เริ่ม--%>
    <div class="col-md-10">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">บันทึกข้อมูลการฝึกอบรม</h3>
            </div>

    <div class="panel-body">
        <%--ชุดที่ 1--%>
        <div class="row">
            <div class="form-group col-md-2">
                <asp:Label ID="lblterm" class="control-label" runat="server" Text="เทอม"></asp:Label>
                <%--เทอม --%>
               <asp:DropDownList ID="DTerm" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" >1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>

            </div> 
            <div class="form-group col-md-2">
                  <asp:Label ID="lblYear"  class="control-label" runat="server" Text="ปีการศึกษา"></asp:Label>
                <asp:DropDownList ID="DYear" runat="server" CssClass="form-control" AppendDataBoundItems="False">
                    <asp:ListItem>2553</asp:ListItem>
                    <asp:ListItem>2554</asp:ListItem>
                    <asp:ListItem>2555</asp:ListItem>
                    <asp:ListItem>2556</asp:ListItem>
                    <asp:ListItem>2557</asp:ListItem>
                    <asp:ListItem>2558</asp:ListItem>
                    <asp:ListItem>2559</asp:ListItem>
                    <asp:ListItem>2560</asp:ListItem>
                </asp:DropDownList> 
            </div> 
            
              <div class="form-group col-md-6">
                <asp:Label ID="Label1" class="control-label" runat="server" Text="วันที่อบรม"></asp:Label> 
                    <asp:TextBox ID="txtDateCourse" runat="server" CssClass=" form-control"></asp:TextBox>
            </div>   
        </div><%-- จบชุดที่1--%>

        <%--ชุดที่2--%>
        <div class="row">
            <div class="form-group col-md-10">
                <asp:Label ID="lblCourse" class="control-label" runat="server" Text="หลักสูตรที่อบรม"></asp:Label>
                <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div> <%--จบชุดที่ 2--%>

          <%--ชุดที่3--%>
        <div class="row">
            <div class="form-group col-md-10">
                <asp:Label ID="lblAddressCourse" class="control-label" runat="server" Text="สถานที่จัดอบรม"></asp:Label>
                <asp:TextBox ID="txtAddressCourse" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div> <%--จบชุดที่ 3--%>


        
          <%--ชุดที่5--%>
        <div class="row">
            <div class="form-group col-md-10">
                <asp:Label ID="lblTotalTimeCourse" class="control-label" runat="server" Text="จำนวนชั่วโมงอบรม (ระบุเฉพาะตัวเลข)"></asp:Label>
                <asp:TextBox ID="txtTotalTimeCourse" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div> <%--จบชุดที่ 5--%>


        <%--บันทึก--%>
        <div class="row">
            <div class="form-group col-md-3 col-md-offset-9">
                <asp:Button ID="cmdSave" runat="server" Text="บันทึก"   class="btn btn-info" />
            </div> <%--จบปุ่มบันทึก--%>

        </div>
                <!-- SET ของ Modal Bootstrap เริ่มจากตรงนี้ -->
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <!-- Bootstrap Modal Dialog -->
                        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding:10%;">
                            <div class="modal-dialog">
                                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="modal-footer">

                                                <asp:Button ID="cmd01" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" runat="server" Text="cmd01" />
                                                 </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


    </div>
    </div>
    </div>

</div> <%--จบประวัติครู--%>
    
</asp:Content>
