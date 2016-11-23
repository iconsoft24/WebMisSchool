<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebShowStudent.aspx.vb" Inherits="MisSchoolWeb.WebShowStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!-- ในหน้าจอมือถือ ไม่ต้อง Zoom และไม่ให้ user Zoom ได้  คือ user-scalable="no" -->
    <meta name="viewport" content="width=device-width, initial-scale=1",user-scalable="no">
    
    <style type="text/css">
        body {top:0;left:0 }
        body,input  {
            font-family : Tahoma,Thonburi; /*Thonburi เป็น Font ใน iPhone*/
            font-size : 13px;
        }

        input[type='checkbox'] {
            height: 20px;
            width: 20px;
            border: 1px solid #ffd800;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
        }

        .BoxMain {width : 100%}

        .BoxTitle {
            background-color: #DDD;
            text-align: center;
            padding: 7px 0px;
            font-weight: bold;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
            border-bottom: solid 1px #AAA;
            width : 100%; 
        }

        .BoxT {
            background-color: #DDD;
            text-align: center;
            padding: 7px 0px;
            font-weight: bold;
            border-bottom-left-radius: 6px;
            border-bottom-right-radius: 6px;
            border-top: solid 1px #AAA;
            width : 100%; 
        }

        #GV1 {margin:15px auto;} /*auto คือการจัดกึ่งกลาง หน้าจอ*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BoxMain">

            <div class="BoxTitle">
                <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
                <div>เช็คชื่อเข้าแถว</div>
            </div>



            <div>
                <asp:GridView ID="GV1" runat="server"
                    BackColor="#DEBA84" BorderColor="#DEBA84"
                    BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" CellSpacing="2"
                    DataKeyNames ="StdNo"
                    OnRowEditing="modEditCommand"
                     OnRowCancelingEdit="modCancelCommand"
                     OnRowDeleting ="modDeleteCommand"
                    AutoGenerateColumns="false"

                    >
                    <Columns>

                        <asp:BoundField DataField="StdNo" HeaderText="รหัสนักเรียน" ReadOnly="true" />

                        <asp:TemplateField HeaderText="ชื่อ">
                            <ItemTemplate>
                                <asp:Label id="lblFname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Fname") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox id="txtEditFname" size="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Fname") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="นามสกุล">
                            <ItemTemplate>
                                <asp:Label id="lblLname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Lname") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox id="txtEditLname" size="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Lname") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton ="True" CancelText="ยกเลิก" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>

                </asp:GridView>
            </div>

            <div class ="BoxT">
                <asp:Button ID="cmdShow" runat="server" Text="แสดงที่เลือก" />
            </div>

            <br />
            <br />
            <asp:Label ID="lblShow" runat="server" Text="Label" Width="80%"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
