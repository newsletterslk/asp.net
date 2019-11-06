<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sample_send.aspx.cs" Inherits="Websms.lk.sample_send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Websms.lk - API Sample For Microsoft .Net / C## Core V1</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
    <!-- Material Design Bootstrap -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.8.10/css/mdb.min.css" rel="stylesheet">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js" ></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.8.10/js/mdb.min.js"></script>
<style>
body,html{
    background:#eee;
}
.headerback {
    background:#006ab9;
    color:#fff;
    text-align: center;
}
</style>
</head>
<body>
     <div class="container">
        <div class="row mt-2">
            <div class="col-12 col-md-8 offset-md-2">
                <div class="alert alert-info">
                    To register and get info, https://app.newsletters.lk/apis
                </div>
                 <form id="websms" runat="server">
                     <div class="card">
            
                        <div class="card-header headerback">API DETAILS</div>
                        <div class="card-body">
                            <div class="md-form">
                                <asp:TextBox ID="sender_id" runat="server" class="form-control" value="WebSMS"></asp:TextBox>
                                <label for="sender_id">Sender ID</label>
                            </div>
                            <div class="md-form">
                                <asp:TextBox ID="api_key" runat="server" class="form-control"></asp:TextBox>
                                <label for="api_key">API KEY</label>
                            </div>
                            <div class="md-form">
                                <asp:TextBox ID="api_token" runat="server" class="form-control"></asp:TextBox>
                                <label for="api_token">API TOKEN</label>
                            </div>
                        </div>
                    </div>
                    <div class="card mt-2">
                        <div class="card-header headerback">MESSAGE</div>
                        <div class="card-body">
                            <div class="md-form">
                                <asp:DropDownList ID="msgType" runat="server"> 
                                    <asp:ListItem Text="SMS" Value="sms"></asp:ListItem> 
                                    <asp:ListItem Text="Voice" Value="voice"></asp:ListItem>
                                    <asp:ListItem Text="MMS" Value="mms"></asp:ListItem> 
                                    <asp:ListItem Text="flash" Value="flash"></asp:ListItem> 
                                    <asp:ListItem Text="Unicode" Value="unicode"></asp:ListItem> 
                                    <asp:ListItem Text="WhatsAPP" Value="whatsapp"></asp:ListItem> 
                                </asp:DropDownList> 
                            </div>
                            <div class="md-form" id="file_sel" style="display:none;">
                                <asp:TextBox ID="file" runat="server" class="form-control"></asp:TextBox>
                                <label for="file">File URL For Voice,MMS,Whatsapp</label>
                            </div>
                            <div class="md-form">
                                <asp:TextBox ID="language" runat="server" class="form-control"></asp:TextBox>
                                <label for="language">Laguage - Default empty</label>
                            </div>
                            <div class="md-form" id="voice_duration" style="display:none;">
                                <asp:TextBox ID="duration" runat="server" class="form-control"></asp:TextBox>
                                <label for="duration">Duration of voice msg</label>
                            </div>
                            <div class="md-form">
                                <asp:TextBox ID="scheduledate" runat="server" class="form-control"></asp:TextBox>
                                <label for="scheduledate">Schedule date Default instant</label>
                            </div>
                            <hr />
                            <div class="md-form">
                                <asp:TextBox ID="mobile" runat="server" class="form-control"></asp:TextBox>
                                <label for="mobile">Mobile Number</label>
                                <small>For Sri Lanka 07XXXXXXXX For Other Countries Enter With Country Code</small>
                            </div>
                            <div class="md-form">
                                <asp:TextBox id="text" TextMode="multiline" Columns="30" Rows="10" runat="server" class="form-control"></asp:TextBox> <br />
                                <label for="text">Message</label>
                                <small>For Type Sinhala Or Tamil Select Unicode To Message Type</small>
                            </div>
                            <hr />
                            <div class="md-form">
                                <div class="row">
                                    <div class="col">
                                        <asp:Button ID="submit_button" runat="server" Text="Send Meassege" class="btn btn-primary btn-lg btn-block" OnClick="submit_button_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
   
</body>
</html>
