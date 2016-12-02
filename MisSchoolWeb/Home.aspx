<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="Home.aspx.vb" Inherits="MisSchoolWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">
<div class="row"> <%--เริ่มประวัติครู--%>
    <div class="col-md-10">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">ข้อมูลประวัติ</h3>
            </div>

    <div class="panel-body">
        <%--ชุดที่ 1--%>
        <div class="row">
            <%--คำนำหน้า--%>
            <div class="form-group col-md-2"> 
                <asp:Label class="control-label" runat="server" Text="คำนำหน้า"></asp:Label>
                <asp:TextBox ID="txtTeacherPrefix" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div> 
            <%--ชื่อ--%>
               <div class="form-group col-md-4"> 
                <asp:Label class="control-label" runat="server" Text="ชื่อ"></asp:Label>
                <asp:TextBox ID="txtTeacherName" runat="server"  CssClass="form-control"></asp:TextBox>
            </div> 
            <%--นามสกุล--%>
             <div class="form-group col-md-4"> 
                <asp:Label class="control-label" runat="server" Text="นามสกุล"></asp:Label>
                <asp:TextBox ID="txtTeacherLName" runat="server"  CssClass="form-control"></asp:TextBox>
            </div> 
            <%--ชื่อเล่น--%>
            <div class="form-group col-md-2"> 
                <asp:Label class="control-label" runat="server" Text="ชื่อเล่น"></asp:Label>
                <asp:TextBox ID="txtTeacherNickname" runat="server" CssClass="form-control"></asp:TextBox>
            </div> 
        </div><%-- จบชุดที่1--%>

        <%--ชุดที่2--%>
        <div class="row">
            <%--เลขบัตรประจำตัวประชาชน--%>
            <div class="form-group col-md-3">
                <asp:Label class="control-label" runat="server" Text="เลขบัตรประจำตัวประชาชน"></asp:Label>
                <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <%--วันเดือนปีเกิด--%>
            <div class="form-group col-md-3">
                <asp:Label class="control-label" runat="server" Text="วันเดือนปีเกิด"></asp:Label>
                <asp:TextBox ID="txtDateBirth" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div> <%--จบชุดที่ 2--%>

        <%--บันทึก--%>
        <div class="row">
            <div class="form-group col-md-3 col-md-offset-9">
                <asp:Button ID="cmdSave" runat="server" Text="บันทึก" />
            </div> <%--จบปุ่มบันทึก--%>

        </div>
        <!-- SET ของ Modal Bootstrap เริ่มจากตรงนี้ -->
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <!-- Bootstrap Modal Dialog -->
                        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                                <%--<button id="cmd01" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" onclick="window.location = '/UserData_List.aspx'">ตกลง</button>--%>
                                                <%-- เติมปุ่มเพิ่มอีกได้ เป็นปุ่ม ASP.Net ก็ได้ --%>
                                                <asp:Button ID="cmd01" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" runat="server" Text="cmd01" />
                                                <asp:Button ID="cmd02" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" runat="server" Text="cmd02" />
                                                <asp:Button ID="cmd03" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" runat="server" Text="cmd03" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <!-- Bootstrap Modal Dialog -->
                        <!-- SET ของ Modal Bootstrap จบตรงนี้ -->
        
    </div>
    </div>
    </div>

</div> <%--จบประวัติครู--%>

     <div class="panel panel-info">
        <div class="panel-heading">
                <h3 class="panel-title">ข้อมูลการลงเวลา</h3>
        </div>
           <div class="form-group">
                    <div class="row">
                        <div class="col-md-10">
                            <asp:GridView ID="GV1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="HisNo" HeaderText="เลขที่บันทึก" ReadOnly="true" />
                                </Columns>

                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />

                            </asp:GridView>
                        </div>
                     </div>
            </div>
         </div>

</asp:Content>
