<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dynamic_Letter_Generation.Home" %>



<!DOCTYPE html>
<html lang="en">
<head>
    <title>Bootstrap Example</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>

    <div class="container">

        <form runat="server" method="post" class="form-horizontal" action="">
            <div class="container">
                <h2>Letter Generation</h2>
                <div class="panel panel-default">
                    <div class="panel-heading">Generate Letter for individual student</div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Course Name:</label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" class="form-control" id="txtCourseName" placeholder="Enter Course Name"/>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Student Name:</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtName" runat="server" class="form-control"  placeholder="Enter Student Name"></asp:TextBox>
                               
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address:</label>
                            <div class="col-sm-10">
                                <asp:TextBox  runat="server" class="form-control" id="txtAddress" placeholder="Enter Address"/>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email:</label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" class="form-control" id="txtEmail" placeholder="Enter email"/>
                            </div>
                        </div>
                  
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnLetterGenerate" runat="server" class="btn btn-default" Text="Generate Letter" OnClick="btnLetterGenerate_Click" />
                            
                        </div>
                    </div>
                </div>
            </div>
    </div>
    </form>
</div>

</body>
</html>
