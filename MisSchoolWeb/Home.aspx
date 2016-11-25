<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MISMain.Master" CodeBehind="Home.aspx.vb" Inherits="MisSchoolWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CB" runat="server">

<div class="panel panel-info">
        <div class="panel-heading">
                <h3 class="panel-title">ประวัติส่วนตัว</h3>
         </div>
        <div class="panel-body">
           <div class="form-group">
                    <div class="row">
                        <div class="col-md-8"> 
                  <label class="teacherhis" for="focusedInput">ชื่อ-สกุล</label></div>
                        <div class="col-md-4"> 
                  <label class="control-label" for="focusedInput">ชื่อเล่น</label></div>
                    </div>


                   <div class="row ">
                       <div class="col-md-8"> 
                       <input class="form-control" id="focusedInput" type="text" value="ชื่อและนามสกุล"  runat="server"></div>
                        <div class="col-md-4"> 
                       <input class="form-control" id="Text2" type="text" value="ชื่อเล่น"  runat="server"></div>
                  </div>


                   <div class="row">
                        <div class="col-md-8"> 
                  <label class="control-label" for="focusedInput">English Name</label></div>
                        <div class="col-md-4"> 
                  <label class="control-label" for="focusedInput">NickName</label></div>
                    </div>


                   <div class="row ">
                       <div class="col-md-8"> 
                       <input class="form-control" id="Text3" type="text" value="Name"  runat="server"></div>
                        <div class="col-md-4"> 
                       <input class="form-control" id="Text5" type="text" value="NickName"  runat="server"></div>
                  </div>



                </div>

                <div class="form-group">
                  <label class="control-label" for="disabledInput">Disabled input</label>
                  <input class="form-control" id="disabledInput" type="text" placeholder="Disabled input here..." disabled=""  runat="server">
                </div>
        </div>
    </div>

</asp:Content>
