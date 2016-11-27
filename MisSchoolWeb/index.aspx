<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="MisSchoolWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="/Scripts/jquery-1.10.2.min.js"></script>
    <script src="/Scripts/jquery-ui.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Style/BJcss/bootstrap.min.css" rel="stylesheet" />
    <link href="/Style/Main/MIS.css" rel="stylesheet" />
     
    <style>
    
     .error1 {color:red; padding: 20px;}
    
    /* On small screens, set height to 'auto' for sidenav and grid */
        @media screen and (max-width: 767px) {
            .row.content {
                height: auto;
            }
        }

    .Noshow{visibility:hidden; }
        .show {
            visibility: visible;
        }
    

    
    </style>  

</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <nav class=" navbar navbar-default">
          <div class="container-fluid">
            <div class="navbar-header">
     <%--         <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>--%>
              <a class="navbar-brand" href="#">Logo</a>

            </div>
          </div>
        </nav>
  
<div class="container-fluid text-center"" >
  <div class="row content">
    <div class="col-sm-12 text-left" >
         <div class="row">
            <!-- Sign In form -->
      <div class="col-md-4 col-md-offset-4 " style="margin-top: 3%;">
      <div class="login-panel panel panel-primary">
          <div class="panel-heading" >
              <h3 class="panel-title">MIS-SCHOOL</h3>
          </div>
           <div class="modal-body">
                  <fieldset>

                    <div class="form-group">
                                     
                          <div>             
                              <asp:TextBox class="form-control"  ID="txtusername" runat="server" placeholder="ชื่อผู้ใช้งาน" required="" autofocus=""></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="กรุณากรอกชื่อผู้ใช้งาน" 
                              ControlToValidate="txtusername" CssClass="error1" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                   <div class="form-group">
                               <div>             
                              <asp:TextBox class="form-control" type="password" ID="txtPassword" runat="server" placeholder="รหัสผ่าน" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="กรุณาป้อนรหัสผ่าน"
                         ControlToValidate="txtPassword" CssClass="error1" Display="Dynamic"></asp:RequiredFieldValidator> 
                          </div>
                          </div>
                          <div><asp:Button  class="btn btn-md btn-primary btn-block" style="background-color:#2A2E5E;"  ID="cmdLogin" runat="server" Text="ตกลง" /></div>
                       <div style="text-align:center;"> 
                           <i  class="glyphicon glyphicon-exclamation-sign" style="color:#b94a48; "></i> <asp:Label ID="Label1" runat="server" Text="ทดสอบ" CssClass="Noshow" 
                                           Style="margin-top: 3%; border: 1px solid transparent; border-radius: 4px;  background-color: #f2dede;
                                           border-color: #eed3d7;color: #b94a48;"></asp:Label></div>
                      
                                       
                                


      
                        

                    
                                      
                                       
                  </fieldset>
                    
          </div>
      </div>
      </div>
    </div>                 
 </div>   
</div>
        </div>


  </div>


  

   
    </form>
</body>
</html>
